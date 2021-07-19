using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;

public class PlayerShoot : Shoot
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

    public static PlayerShoot instance;
    
    //Récupération des component des boutons du HUD pour éviter de tirer en cliquant dessus (voir Shoot())
    [SerializeField] GraphicRaycaster raycasterHUDtourelles;
    [SerializeField] GraphicRaycaster raycasterHUDshop;
    EventSystem eventSystemHUDtourelles;
    
    //UnityEvent
    //Met à jour les munitions dans le HUD
    [SerializeField] private UnityEvent onShoot;
    [SerializeField] private UnityEvent onReload;
    [SerializeField] private UnityEvent onFinishReload;

    private void OnEnable()
    {
        //passage du nombre de balle max au texte du HUD
        BulletCountdown.maxBullet = playerGunSO.maxBullet;
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    //tir
    public void OnShoot(InputAction.CallbackContext obj)
    {
        //Si le clique est maintenu
        if(obj.phase == InputActionPhase.Performed)
        {
            OnShootPerformed(obj);
        }
        //Si le clique est relaché
        else if(obj.phase == InputActionPhase.Canceled)
        {
            OnShootCanceled(obj);
        }
    }

        private void OnShootPerformed(InputAction.CallbackContext obj)
    {
        //Si le joueur n'a pas cliqué sur un élément de HUD
        if (!playerGunSO.isClickingHUD(eventSystemHUDtourelles, mousePosition.mousePos, raycasterHUDtourelles) && !playerGunSO.isClickingHUD(eventSystemHUDtourelles, mousePosition.mousePos, raycasterHUDshop))
            canShoot = true;
    }

    private void OnShootCanceled(InputAction.CallbackContext obj)
    {
        canShoot = false;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        //Relance les éléments du start de Shoot.cs (qui dérive ce script)
        base.Start();
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
    public override void Shooting()
    {
        //Vérifie si le joueur peux tirer
        if(canShoot && Time.time > lastShoot + playerGunSO.shootTimer && remainBullet > 0 && !isReloading)
        {
        //Relance les éléments du Shooting de Shoot.cs (qui dérive ce script)
        base.Shooting();

        onShoot.Invoke();
        remainBullet = remainBullet - 1;
        }
    }

    //Recharge
    public void Reload(InputAction.CallbackContext obj)
    {
        if (remainBullet != playerGunSO.maxBullet && obj.started)
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

    public void IncreaseMaxBullet()
    {
        //Nombre de balle disponible = au nombre de balle maximum
        remainBullet = playerGunSO.maxBullet;
    }
}
