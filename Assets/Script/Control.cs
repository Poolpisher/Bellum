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
        //Test Variable:
        /*
        Debug.Log(layerMask);
        Debug.Log(Event.current);
        Debug.Log(mousePos);
        Debug.Log(point);
        */

        //Raycast avec la position de la souris
        Debug.Log(mousePos);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(mousePos, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(mousePos, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(mousePos, transform.TransformDirection(Vector3.down) * 1000, Color.white);
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

    void OnGUI()
    {
        //Debug Taille de l'écran/Position de la souris/World position (je sais pas ce que c'est)
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Mise a jour de la vitesse
        rigidbody.velocity = inputValue * speed;

        //Mise a jour de la position de la souris dans la variable mousePos
        /*
            Vector3 point = new Vector3();
            Event currentEvent = Event.current;
            Vector2 mousePos = new Vector2();

            // Get the mouse position from Event.
            // Note that the y position from Event is inverted.
            mousePos.x = currentEvent.mousePosition.x;
            mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            */
    }
}
