using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    //Vitesse du joueur
    [SerializeField] private int speed;
    //Projectile
    [SerializeField] private GameObject bulletPrefab;
    //Vitesse du joueur
    [SerializeField] private int layerMask;
    //Orientation du joueur
    private Vector2 inputValue;

    private Camera cam;
    private Event currentEvent;
    private Vector3 point;
    private Vector2 mousePos;

    private Player playerInput;
    private Rigidbody rigidbody;

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
        //Orientation du tir
        var shootinputValue = obj.ReadValue<Vector2>();
        //Créer le projectile
        var createBullet = Instantiate(bulletPrefab, rigidbody.position, Quaternion.identity);
        createBullet.GetComponent<Bullet>().fixinputValue = shootinputValue;
    }

    //Déplacement
    private void Move(InputAction.CallbackContext obj)
    {
        inputValue = obj.ReadValue<Vector2>();
    }
    //Arret du déplacement
    private void Stop(InputAction.CallbackContext obj)
    {
        inputValue = Vector2.zero;
    }

    private void Click(InputAction.CallbackContext obj)
    {
        Debug.Log(layerMask);
        Debug.Log(Event.current);
        Debug.Log(Event.current.mousePosition);
        Debug.Log(mousePos);
        Debug.Log(point);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Event.current.mousePosition, transform.TransformDirection(point), out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(Event.current.mousePosition, transform.TransformDirection(point) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void MousePosition(InputAction.CallbackContext obj)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        //Mise a jour de la vitesse
        rigidbody.velocity = inputValue * speed;
    }
}
