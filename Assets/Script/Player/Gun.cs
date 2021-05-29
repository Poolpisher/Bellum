using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    //Référence de l'arme du joueur
    [SerializeField] private PlayerGunSO playerGunSO;
    //Si le joueur peux tirer
    private bool canShoot;
    private bool isReloading;
    //Animator
    private Animator myAnimator;

    //Nombre de balles restantes
    private int remainBullet;
    
    //Layer mask pour ouvrir les différents HUD
    [SerializeField] private LayerMask HUDtourelles;
    //Récupération des component des boutons du HUD pour éviter de tirer en cliquant dessus (voir Shoot())
    [SerializeField] GraphicRaycaster raycasterHUDtourelles;
    EventSystem eventSystemHUDtourelles;
    //Position de la souris dans le HUD
    PointerEventData pointerEventDataHUDtourelles;
    
        //UnityEvent
        //Met à jour les munitions dans le HUD
        [SerializeField] private UnityEvent onShoot;
        [SerializeField] private UnityEvent onReload;
        [SerializeField] private UnityEvent onFinishReload;

    //Orientation du joueur
    private Vector2 inputValue;
    //Temps correspondant au dernier tir
    private float lastShoot;
    //Rigidbody
    private new Rigidbody rigidbody;

    private MousePosition mousePosition;
    private Shoot shoot;

    void Awake()
    {
        mousePosition = GetComponent<MousePosition>();
        shoot = GetComponent<Shoot>();
    }

    private void OnEnable()
    {
        //passage du nombre de balle max au texte du HUD
        BulletCountdown.maxBullet = playerGunSO.maxBullet;
    }

    //tir
    public void Shoot(InputAction.CallbackContext obj)
    {
        if (!playerGunSO.isClickingHUD(eventSystemHUDtourelles, mousePosition.mousePos, raycasterHUDtourelles))
        Debug.Log("tir");
    }

    private void StopShoot(InputAction.CallbackContext obj)
    {
        canShoot = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        myAnimator = GetComponent<Animator>();
        eventSystemHUDtourelles = GameObject.FindWithTag("EventSystem").GetComponent<EventSystem>();

        //Nombre de balle disponible = au nombre de balle maximum
        remainBullet = playerGunSO.maxBullet;        
    }

    void Update()
    {
        //Tir
        Shooting();
    }

    // Fonction de tir
    private void Shooting()
    {
        if(canShoot && shoot.actualTime > lastShoot + playerGunSO.shootTimer && remainBullet > 0 && !isReloading)
        {
        shoot.Shooting();

        onShoot.Invoke();
        remainBullet = remainBullet - 1;
        }
    }
    //Recharge
    public void Reload(InputAction.CallbackContext obj)
    {
        if (remainBullet != playerGunSO.maxBullet)
        {
        //Lance la coroutine suivante
        StartCoroutine(ReloadAnimation());
        }
    }
    // Animation de recharge et remise à niveau des variables
    private IEnumerator ReloadAnimation()
    {
        isReloading = true;
        myAnimator.SetTrigger("Reload");
        //Récupération de la durée de l'animation
        var waitForReloading = myAnimator.GetCurrentAnimatorStateInfo(0).length;
        //Lance la fonction OnReload de l'inspecteur
        onReload.Invoke();
        //attends d'avoir recharger
        yield return new WaitForSeconds(waitForReloading * 2);
        isReloading = false;
        //Lance la fonction onFinishReload de l'inspecteur
        onFinishReload.Invoke();
        //Nombre de balle disponible = au nombre de balle maximum
        remainBullet = playerGunSO.maxBullet;
    }
}
