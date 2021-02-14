using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;

public class Control : MonoBehaviour
{
    //Son clique sur les plateformes
    AudioSource m_MyAudioSource;
    
    //Vitesse du joueur
    [SerializeField] private int speed;
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
    [SerializeField] private LayerMask HUDshop;
    //Récupération des component des boutons du HUD pour éviter de tirer en cliquant dessus (voir Shoot())
    [SerializeField] GraphicRaycaster raycasterHUDtourelles;
    //Range de la tourelle
    public static GameObject getRange;
    EventSystem eventSystemHUDtourelles;
    //Position de la souris dans le HUD
    PointerEventData pointerEventDataHUDtourelles;
    //Temps entre 2 balles
    [SerializeField] private float shootTimer;
        //UnityEvent
        //Affiche/Désaffiche le HUD des tourelles
        [SerializeField] private UnityEvent onClickVoid;
        //Affiche le bouton create et désaffiche le bouton destroy du HUD des tourelles
        [SerializeField] private UnityEvent canCreateSentryHUD;
        //Affiche le bouton destroy et désaffiche le bouton create du HUD des tourelles
        [SerializeField] private UnityEvent canDestroySentryHUD;

        //Passe la position d'une plateforme au script Sentry_Creation
        [SerializeField] private Transform_Event onClickPlateform;
        //Ouvre le HUD du magasin
        [SerializeField] private Transform_Event onClickShop;
        //Met à jour les munitions dans le HUD
        [SerializeField] private UnityEvent onShoot;
        [SerializeField] private UnityEvent onReload;
        [SerializeField] private UnityEvent onFinishReload;

    //Orientation du joueur
    private Vector2 inputValue;
    private Vector3 inputValue3D;
    //HUD
    private GameObject HUD;
    //Caméra
    private Camera cam;
    //Permet de récupérer la position de la souris
    private Event currentEvent;
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
        playerInput.Action.Move.performed += Move;
        playerInput.Action.Move.canceled += Stop;
        playerInput.Action.Shoot.performed += Shoot;
        playerInput.Action.Shoot.canceled += StopShoot;
        playerInput.Action.MouseClick.performed += Click;
        playerInput.Action.MousePosition.performed += MousePosition;
        playerInput.Action.Reload.performed += Reload;
        playerInput.Action.Antebellum.performed += GameManager.Instance.Antebellum;

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
    
    //Déplacement
    private void Move(InputAction.CallbackContext obj)
    {
        inputValue = obj.ReadValue<Vector2>();
        inputValue3D = new Vector3(inputValue.x, 0, inputValue.y);
    }
    //Arret du déplacement
    private void Stop(InputAction.CallbackContext obj)
    {
        inputValue3D = Vector2.zero;
    }

    /// <summary>
    /// Vérifie ou la souris est placée dans la fenetre du jeu lors d'un clique
    /// </summary>
    private void Click(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cam.transform.position, point - cam.transform.position, out hit, Mathf.Infinity, HUDtourelles))
        {
            //Désaffiche la range de la tourelle précedemment seliectionné
            if(getRange != null)
            {
            getRange.SetActive(false);
            }
            //Passe la position pour créer la tourelle via l'inspecteur (qui passe nottament la position de la plateforme au script Sentry_Management)
            onClickPlateform.Invoke(hit.transform);
            //Si une tourelle est présente sur la plateforme sélectionné
            if(hit.transform.childCount > 0)
            {
            //Récupère la range
            getRange = hit.transform.GetChild(0).Find("Range").gameObject;
            //Affiche le bouton destroy et désaffiche le bouton create du HUD des tourelles
            canDestroySentryHUD.Invoke();
            //Affiche la range de la tourelle
            getRange.SetActive(true);
            }
            //Si une tourelle n'est pas présente sur la plateforme sélectionné
            else
            {
            //Désaffiche la range de la tourelle précedemment seliectionné
            if(getRange != null)
            {
            getRange.SetActive(false);
            }
            //Affiche le bouton create et désaffiche le bouton destroy du HUD des tourelles
            canCreateSentryHUD.Invoke();
            }
            
            //Récupere le component GraphicRaycaster pour repérer les boutons du HUD
            if (raycasterHUDtourelles == null)
            {
                raycasterHUDtourelles = GameObject.FindWithTag("HUDtourelles").GetComponent<GraphicRaycaster>();
            }
        }
        else if (Physics.Raycast(cam.transform.position, point - cam.transform.position, out hit, Mathf.Infinity, HUDshop))
        {
            //Passe la position pour créer la tourelle
            onClickShop.Invoke(hit.transform);
        }
        else
        {
            //Désaffiche le HUD des tourelles
            onClickVoid.Invoke();
            //Désaffiche la range
            if(getRange != null)
            {
            getRange.SetActive(false);
            }
        }
    }
    
    private void MousePosition(InputAction.CallbackContext obj)
    {
        mousePos = obj.ReadValue<Vector2>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //récupération du son de clique
        m_MyAudioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();

        cam = Camera.main;
        //Enregistre les éléments du HUD pour les supprimer/réafficher via les variables
        HUD = GameObject.FindGameObjectWithTag("HUD");

        myAnimator = GetComponent<Animator>();
        eventSystemHUDtourelles = GameObject.FindWithTag("EventSystem").GetComponent<EventSystem>();

        //Nombre de balle disponible = au nombre de balle maximum
        remainBullet = maxBullet;

    }
    /// <summary>
    /// Vérifie la position de la souris et si le joueur est en train de recharger en lancant Shooting()
    /// </summary>
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
        //Si le joueur peux tirer et que le temps actuel est supérieur à celui du dernier tir + le temps minimum requis entre chaque tir
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
        //Lance la fonction OnReload de l'inspecteur
        onReload.Invoke();
        //attends 2 secondes
        yield return new WaitForSeconds(2);
        isReloading = false;
        //Lance la fonction onFinishReload de l'inspecteur
        onFinishReload.Invoke();
        //Nombre de balle disponible = au nombre de balle maximum
        remainBullet = maxBullet;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Mise a jour de la vitesse
        rigidbody.velocity = inputValue3D * speed;
    }
}
