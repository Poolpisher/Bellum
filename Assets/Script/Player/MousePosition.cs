using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class MousePosition : MonoBehaviour, IMousePositionProvider
{
    //Caméra
    private Camera cam;
    public Vector3 look{get; private set;}
    public Vector3 worldMousePos{get; private set;}
    //Position de la souris
    public Vector2 mousePos{get; private set;}
    public float aimAngle{get; private set;}
    
    public void OnPlayerRotation(InputAction.CallbackContext obj)
    {
        CalculateMousePos(obj.ReadValue<Vector2>());
    }

    public void CalculateMousePos(Vector2 rawPos)
    {
        mousePos = rawPos;
        //Transformation de la position de la souris dans le monde
        worldMousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, (transform.position - cam.transform.position).magnitude));
        //Distance entre le joueur et la souris et Changement de l'orientation de la balle en fonction de la souris
        look = (worldMousePos - transform.position).normalized;
        //Calcul de l'angle a partir de "look"
        aimAngle = Vector3.SignedAngle(Vector3.forward , look, Vector3.down);
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
