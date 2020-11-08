using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Events;

public class Control : MonoBehaviour
{
    //Son clique sur les plateformes
    AudioSource m_MyAudioSource;

    //Vitesse du joueur
    [SerializeField] private int speed;
    //Si le joueur peux tirer
    [SerializeField] private bool canShoot;
    //Projectile
    [SerializeField] private GameObject bulletPrefab;

    //Nombre de balles restantes
    private int remainBullet;
    //Nombre maximum de balles
    [SerializeField] private int maxBullet;

    //Vitesse du joueur
    [SerializeField] private LayerMask layerMask;
    //Temps entre 2 balles
    [SerializeField] private float shootTimer;
    //HUD Plateforme tourelle
    [SerializeField] private GameObject HUDmenu;
    //Affiche/Désaffiche le HUD des tourelles
    [SerializeField] private UnityEvent onClickPlateform;
    [SerializeField] private UnityEvent onClickVoid;
    //Passe la position d'une plateforme au script Sentry_Creation
    [SerializeField] private Vector3_Event onClickVector3;

    [SerializeField] private UnityEvent onShoot;
    [SerializeField] private UnityEvent onReload;

    //Orientation du joueur
    private Vector2 inputValue;
    private Vector3 inputValue3D;
    //HUD
    private GameObject HUD;
    //Caméra
    private Camera cam;
    //Permet de récupérer la position de la souris
    private Event currentEvent;
    //???
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

    //Activation des controles
    private void OnEnable()
    {
        playerInput = new Player();
        playerInput.Enable();
        playerInput.Action.Move.performed += Move;
        playerInput.Action.Move.canceled += Stop;
        playerInput.Action.Shoot.performed += Shoot;
        playerInput.Action.Shoot.canceled += StopShoot;
        playerInput.Action.MouseClick.performed += Click;
        playerInput.Action.MousePosition.performed += MousePosition;
        playerInput.Action.Reload.performed += Reload;

        //passage du nombre de balle max au texte du HUD
        BulletCountdown.maxBullet = maxBullet;
    }

    //tir
    void Shoot(InputAction.CallbackContext obj)
    {
            canShoot = true;
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

    private void Click(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cam.transform.position, point - cam.transform.position, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(cam.transform.position, point - cam.transform.position, Color.yellow);
            //Affiche le HUD des tourelles
            onClickPlateform.Invoke();
            //Passe la position pour créer la tourelle
            onClickVector3.Invoke(hit.transform.position);
        }
        else
        {
            //Le HUD ne s'affiche pas
            Debug.DrawRay(cam.transform.position, point - cam.transform.position, Color.white);
            //Désaffiche le HUD des tourelles
            onClickVoid.Invoke();
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

    private void Shooting()
    {
        //Calcul du temps lors du tir
        var actualTime = Time.time;
        //Si le joueur peux tier et que le temps actuel est supérieur à celui du dernier tir + le temps minimum requis entre chaque tir
        if (canShoot && actualTime > lastShoot + shootTimer && remainBullet > 0)
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

    void Reload(InputAction.CallbackContext obj)
    {
        canShoot = false;
        onReload.Invoke();
        //Nombre de balle disponible = au nombre de balle maximum
        remainBullet = maxBullet;

        canShoot = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Mise a jour de la vitesse
        rigidbody.velocity = inputValue3D * speed;
    }
}
