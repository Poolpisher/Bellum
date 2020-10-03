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

    //Caméra
    private Camera cam;
    //Permet de récupérer la position de la souris
    private Event currentEvent;
    //???
    private Vector3 point;
    //Position de la souris
    private Vector2 mousePos;
    private Vector2 mousePos2;

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
        inputValue3D = new Vector3(inputValue.x, 0, inputValue.y);
    }
    //Arret du déplacement
    private void Stop(InputAction.CallbackContext obj)
    {
        inputValue3D = Vector2.zero;
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
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, (transform.position - cam.transform.position).magnitude));
        var debugCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        debugCube.transform.position = point;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cam.transform.position, point-cam.transform.position, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(cam.transform.position, point - cam.transform.position, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(cam.transform.position, point - cam.transform.position, Color.white);
            Debug.Log("Did not Hit");
            //Debug.Break();
        }
    }

    private void MousePosition(InputAction.CallbackContext obj)
    {
        mousePos = obj.ReadValue<Vector2>();
        Debug.Log(mousePos + "MousePosition");
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main;
    }
    /*
    void OnGUI()
    {
        //Debug Taille de l'écran/Position de la souris/
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos2 = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos2.x = currentEvent.mousePosition.x;
        mousePos2.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos2.x, mousePos2.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos2);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }
    */
    // Update is called once per frame
    void FixedUpdate()
    {
        //Mise a jour de la vitesse
        rigidbody.velocity = inputValue3D * speed;

        /*
        //Mise a jour de la position de la souris dans la variable mousePos
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
