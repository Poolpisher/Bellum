using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Contrôle
    public Player playerInput;
    //Caméra
    private Camera cam;
    [HideInInspector]public Vector3 look;
    [HideInInspector]public Vector3 worldMousePos;
    //Position de la souris
    [HideInInspector]public Vector2 mousePos;
    public static InputManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    private void OnEnable()
    {
        //Activation des controles
        playerInput = new Player();
        playerInput.Enable();
        playerInput.Action.MousePosition.performed += MousePosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Transformation de la position de la souris dans le monde
        worldMousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, (transform.position - cam.transform.position).magnitude));
        //Distance entre le joueur et la souris et Changement de l'orientation de la balle en fonction de la souris
        look = (worldMousePos - transform.position).normalized;
        //Calcul de l'angle a partir de "look"
        var aimAngle = Vector3.SignedAngle(Vector3.forward , look, Vector3.down);
        //Application de l'angle sur la rotation du joueur
        transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.down);
    }

    private void MousePosition(InputAction.CallbackContext obj)
    {
        mousePos = obj.ReadValue<Vector2>();
    }
}
