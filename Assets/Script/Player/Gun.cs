using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    //Si le joueur peux tirer
    private bool canShoot;
    private bool isReloading;
    //Projectile
    [SerializeField] private GameObject bulletPrefab;
    //Animator
    private Animator myAnimator;

    //Nombre de balles restantes
    private int remainBullet;
    //Nombre maximum de balles
    [SerializeField] private int maxBullet;
    
    //Layer mask pour ouvrir les différents HUD
    [SerializeField] private LayerMask HUDtourelles;
    //Récupération des component des boutons du HUD pour éviter de tirer en cliquant dessus (voir Shoot())
    [SerializeField] GraphicRaycaster raycasterHUDtourelles;
    EventSystem eventSystemHUDtourelles;
    //Position de la souris dans le HUD
    PointerEventData pointerEventDataHUDtourelles;
    //Temps entre 2 balles
    [SerializeField] private float shootTimer;
    
        //UnityEvent
        //Met à jour les munitions dans le HUD
        [SerializeField] private UnityEvent onShoot;
        [SerializeField] private UnityEvent onReload;
        [SerializeField] private UnityEvent onFinishReload;

    //Orientation du joueur
    private Vector2 inputValue;
    //HUD
    private GameObject HUD;
    //Caméra
    private Camera cam;
    private Vector3 look;
    private Vector3 point;
    //Position de la souris
    private Vector2 mousePos;
    //Control
    private Player playerInput;
    //Temps correspondant au dernier tir
    private float lastShoot;
    //Rigidbody
    private new Rigidbody rigidbody;
    private void OnEnable()
    {
        //Activation des controles
        playerInput = new Player();
        playerInput.Enable();
        playerInput.Action.Shoot.performed += Shoot;
        playerInput.Action.Shoot.canceled += StopShoot;
        playerInput.Action.Reload.performed += Reload;
        playerInput.Action.MousePosition.performed += MousePosition;

        //passage du nombre de balle max au texte du HUD
        BulletCountdown.maxBullet = maxBullet;
    }

    //tir
    void Shoot(InputAction.CallbackContext obj)
    {
        //Vérifie si le clique collisione avec un bouton du HUD
        bool raycastResult = false;

        //Set up the new Pointer Event
        pointerEventDataHUDtourelles = new PointerEventData(eventSystemHUDtourelles);
        //Set the Pointer Event Position to that of the mouse position
        pointerEventDataHUDtourelles.position = mousePos;
        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();
        //Raycast using the Graphics Raycaster and mouse click position
        raycasterHUDtourelles.Raycast(pointerEventDataHUDtourelles, results);
        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            //Vérifie si le clique collisione avec un objet ayant le tag "Button"
            raycastResult = result.gameObject.CompareTag("Button");
            //Permet d'arrêter la verification si un bouton a été trouvé
            if (raycastResult)
            {
                break;
            }
        }
        //Permet de tirer si le joueur ne clique pas sur un bouton
        canShoot = !raycastResult;
    }

    private void StopShoot(InputAction.CallbackContext obj)
    {
        canShoot = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        cam = Camera.main;
        //Enregistre les éléments du HUD pour les supprimer/réafficher via les variables
        HUD = GameObject.FindGameObjectWithTag("HUD");

        myAnimator = GetComponent<Animator>();
        eventSystemHUDtourelles = GameObject.FindWithTag("EventSystem").GetComponent<EventSystem>();

        //Nombre de balle disponible = au nombre de balle maximum
        remainBullet = maxBullet;        
    }

    void Update()
    {
        //Transformation de la position de la souris dans le monde
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, (transform.position - cam.transform.position).magnitude));
        //Distance entre le joueur et la souris et Changement de l'orientation de la balle en fonction de la souris
        look = (point - transform.position).normalized;
        //Calcul de l'angle a partir de "look"
        var aimAngle = Vector3.SignedAngle(Vector3.forward , look, Vector3.down);
        //Application de l'angle sur la rotation du joueur
        transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.down);
        
        //Tir
        Shooting();
    }

    // Fonction de tir
    private void Shooting()
    {
        //Calcul du temps lors du tir
        var actualTime = Time.time;
        //Si le joueur peux tier et que le temps actuel est supérieur à celui du dernier tir + le temps minimum requis entre chaque tir
        if (canShoot && actualTime > lastShoot + shootTimer && remainBullet > 0 && !isReloading)
        {
            //Création de la balle
            var createBullet = Instantiate(bulletPrefab, rigidbody.position, Quaternion.identity);
            //Orientation de la balle
            createBullet.GetComponent<Bullet>().fixinputValue = look;
            //Changement de la valeur du dernier tir
            lastShoot = actualTime;

            onShoot.Invoke();
            remainBullet = remainBullet - 1;
        }
    }
    //Recharge
    void Reload(InputAction.CallbackContext obj)
    {
        if (remainBullet != maxBullet)
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
        Debug.Log(waitForReloading);
        //Lance la fonction OnReload de l'inspecteur
        onReload.Invoke();
        //attends d'avoir recharger
        yield return new WaitForSeconds(waitForReloading * 2);
        isReloading = false;
        //Lance la fonction onFinishReload de l'inspecteur
        onFinishReload.Invoke();
        //Nombre de balle disponible = au nombre de balle maximum
        remainBullet = maxBullet;
    }
    
    private void MousePosition(InputAction.CallbackContext obj)
    {
        mousePos = obj.ReadValue<Vector2>();
    }
}
