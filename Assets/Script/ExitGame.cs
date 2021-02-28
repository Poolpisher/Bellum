using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    //Control
    private Player playerInput;
    private void OnEnable()
    {
        //Activation des controles
        playerInput = new Player();
        playerInput.Enable();
        playerInput.Action.Exit.performed += doExitGame;
    }

    public void doExitGame(InputAction.CallbackContext obj) 
    {
        Application.Quit();
    }
}
