using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;

public class Click : MonoBehaviour
{
    //Son clique sur les plateformes
    AudioSource m_MyAudioSource;
    
    //Animator
    private Animator myAnimator;
    
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
    //Rigidbody
    private new Rigidbody rigidbody;

    private void OnEnable()
    {
        //Activation des controles
        playerInput = new Player();
        playerInput.Enable();
        playerInput.Action.MouseClick.performed += Clique;
        playerInput.Action.MousePosition.performed += MousePosition;
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
    }

    // Update is called once per frame
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
    }

    /// <summary>
    /// Vérifie ou la souris est placée dans la fenetre du jeu lors d'un clique
    /// </summary>
    private void Clique(InputAction.CallbackContext obj)
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
}
