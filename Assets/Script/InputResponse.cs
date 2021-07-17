using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputResponse : MonoBehaviour
{
    [SerializeField] GameEventSO leftShortcut;
    [SerializeField] GameEventSO rightShortcut;
    /*
    [SerializeField] GameEventSO onPlayerRotation;
    [SerializeField] GameEventSO onGameManagerAntebellum;
    */

    public void OnLeftShortcut(InputAction.CallbackContext obj)
    {
        if(obj.started)
        {
            leftShortcut.Raise();
        }
    }

    public void OnRightShortcut(InputAction.CallbackContext obj)
    {
        if(obj.started)
        {
            rightShortcut.Raise();
        }
    }

/*
    public void OnPlayerRotation(InputAction.CallbackContext obj)
    {
        if(obj.started)
        {
            onPlayerRotation.Raise();
        }
    }

    public void OnGameManagerAntebellum(InputAction.CallbackContext obj)
    {
        if(obj.started)
        {
            onGameManagerAntebellum.Raise();
        }
    }
    */
}
