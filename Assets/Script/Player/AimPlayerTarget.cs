using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class AimPlayerTarget : MonoBehaviour
{
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChangeController(PlayerInput playerInput)
    {
        
    }

    public void OnPlayerRotation(InputAction.CallbackContext obj)
    {
        //Vérifie si l'input est actif
        if(obj.phase != InputActionPhase.Performed)
        return;
        //Sauvegarde la valeur de l'input brut
        var rawInput = obj.ReadValue<Vector2>();
        //Si l'input est inférieur ou égal à 1
        if(rawInput.sqrMagnitude <= 1)
        {
            //Choisis la visée à la manette
            RightJoystickMove(rawInput);
        }
        //Sinon choisis la visée à la souris
        else
        {
            MouseMove(rawInput);
        }
    }

    void RightJoystickMove(Vector2 stickPosition)
    {
        transform.position = player.position + new Vector3(stickPosition.x, 0, stickPosition.y);
    }

    void MouseMove(Vector2 mousePosition)
    {
        //Transformation de la position de la souris dans le monde
        var myVector = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, (transform.position - Camera.main.transform.position).magnitude));
        //Applique la position du joueur en y à la position du AimTarget
        myVector.y = player.position.y;
        transform.position = myVector;
    }
}
