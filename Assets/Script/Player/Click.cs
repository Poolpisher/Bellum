using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Click : MonoBehaviour
{
    //Son clique sur les plateformes
    AudioSource m_MyAudioSource;

    //Layer mask pour ouvrir les différents HUD
    [SerializeField] private LayerMask HUDtourelles;
    [SerializeField] private LayerMask HUDshop;
    //Récupération des component des boutons du HUD pour éviter de tirer en cliquant dessus (voir Shoot())
    [SerializeField] GraphicRaycaster raycasterHUDtourelles;
    //Range de la tourelle
    public static GameObject getRange;
    //Derniere plateforme selectionné par le raycast (pour le HUD des tourelles)
    private SentryBehaviour lastHitSelected;
    EventSystem eventSystemHUDtourelles;

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

    //HUD
    private GameObject HUD;
    //Caméra
    private Camera cam;
    
    private MousePosition mousePosition;

    void Awake()
    {
        mousePosition = GetComponent<MousePosition>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //récupération du son de clique
        m_MyAudioSource = GetComponent<AudioSource>();

        cam = Camera.main;
        //Enregistre les éléments du HUD pour les supprimer/réafficher via les variables
        HUD = GameObject.FindGameObjectWithTag("HUD");

        eventSystemHUDtourelles = GameObject.FindWithTag("EventSystem").GetComponent<EventSystem>();
    }

    /// <summary>
    /// Vérifie ou la souris est placée dans la fenetre du jeu lors d'un clique
    /// </summary>
    public void Clique(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cam.transform.position, mousePosition.worldMousePos - cam.transform.position, out hit, Mathf.Infinity, HUDtourelles))
        {
            //Désaffiche la range de la tourelle précedemment seliectionné
            if (getRange != null)
            {
                getRange.SetActive(false);
            }
            //Passe la position pour créer la tourelle via l'inspecteur (qui passe nottament la position de la plateforme au script Sentry_Management)
            onClickPlateform.Invoke(hit.transform);
            //Si une tourelle est présente sur la plateforme sélectionné
            if (hit.transform.childCount > 0)
            {
                SentrySelected(hit);
            }
            //Si une tourelle n'est pas présente sur la plateforme sélectionné
            else
            {
                EmptyPlatformSelected();
            }

            //Récupere le component GraphicRaycaster pour repérer les boutons du HUD
            if (raycasterHUDtourelles == null)
            {
                raycasterHUDtourelles = GameObject.FindWithTag("HUDtourelles").GetComponent<GraphicRaycaster>();
            }
        }
        else if (Physics.Raycast(cam.transform.position, mousePosition.worldMousePos - cam.transform.position, out hit, Mathf.Infinity, HUDshop))
        {
            //Passe la position pour créer la tourelle
            onClickShop.Invoke(hit.transform);
        }
        else
        {
            //Désaffiche le HUD des tourelles
            onClickVoid.Invoke();
            //Désaffiche la range
            if (getRange != null)
            {
                getRange.SetActive(false);
            }
        }
    }

    private void SentrySelected(RaycastHit hit)
    {
        //Récupère la range
        getRange = hit.transform.GetChild(0).Find("Range").gameObject;
        //Affiche le bouton destroy et désaffiche le bouton create du HUD des tourelles
        canDestroySentryHUD.Invoke();
        //Sauvegarde la derniere tourelle selectionné
        lastHitSelected = hit.transform.GetComponentInChildren<SentryBehaviour>();
            //Debug.Log(lastHitSelected.isSelected);
        //Change le booléen qui confirme si une tourelle est selectionné
        lastHitSelected.isSelected = true;
        //Affiche les HP actuels de la tourelle
        SentryHealthBehaviour.instance.DisplayScore(lastHitSelected.sentryHealth);
        //Affiche la range de la tourelle
        getRange.SetActive(true);
    }

    private void EmptyPlatformSelected()
    {
        if (lastHitSelected != null)
        {
            //Change le booléen qui confirme si une tourelle est selectionné
            lastHitSelected.isSelected = false;
            lastHitSelected = null;
            //Debug.Log(lastHitSelected.isSelected);
        }
        //Désaffiche la range de la tourelle précedemment seliectionné
        if (getRange != null)
        {
            getRange.SetActive(false);
        }
        //Affiche le bouton create et désaffiche le bouton destroy du HUD des tourelles
        canCreateSentryHUD.Invoke();
    }
}
