using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    //Vitesse du joueur
    [SerializeField] private int speed;
    //Projectile
    [SerializeField] private GameObject bulletPrefab;
    //Vitesse du joueur
    [SerializeField] private LayerMask layerMask;
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
    private Vector3 point;
    //Position de la souris
    private Vector2 mousePos;

    //Control
    private Player playerInput;
    private new Rigidbody rigidbody;

    //Activation des controles
    private void OnEnable()
    {
        playerInput = new Player();
        playerInput.Enable();
        playerInput.Action.Move.performed += Move;
        playerInput.Action.Move.canceled += Stop;
        playerInput.Action.Shoot.performed += Shoot;
        playerInput.Action.MouseClick.performed += Click;
        playerInput.Action.MousePosition.performed += MousePosition;
    }

    //tir
    void Shoot(InputAction.CallbackContext obj)
    {
        Debug.Log(mousePos + "mousePos");
        //Orientation du tir
            //Il faut maintenir l'axe y au niveau du joueur
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, transform.position.y, mousePos.y));
        Debug.Log(point + "point");

        //Raycast avec la position de la souris
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, point, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, point, Color.yellow);
            Debug.Log("Did Hit");
            //Debug.Break();
        }
        else
        {
            Debug.DrawRay(transform.position, point, Color.white);
            Debug.Log("Did not Hit");
            //Debug.Break();
        }
        var shootinputValue = mousePos;
        //Créer le projectile
        var createBullet = Instantiate(bulletPrefab, rigidbody.position, Quaternion.identity);
        createBullet.GetComponent<Bullet>().fixinputValue = point;
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
        //Raycast avec la position de la souris
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, (transform.position - cam.transform.position).magnitude));

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cam.transform.position, point - cam.transform.position, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(cam.transform.position, point - cam.transform.position, Color.yellow);
            Debug.Log("Did Hit");
                //Le HUD ne s'affiche pas
            //active canvas HUD
            HUD.SetActive(true);
        }
        else
        {
            Debug.DrawRay(cam.transform.position, point - cam.transform.position, Color.white);
            Debug.Log("Did not Hit");
            //Debug.Break();

            //désactive canvas HUD
            HUD.SetActive(false);
        }
    }

    private void MousePosition(InputAction.CallbackContext obj)
    {
        mousePos = obj.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main;
        //Enregistre les éléments du HUD pour les supprimer/réafficher via les variables
        HUD = GameObject.FindGameObjectWithTag("HUD");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Mise a jour de la vitesse
        rigidbody.velocity = inputValue3D * speed;
    }
}
