using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    public GameEventSO eventSO;
    public UnityEvent response;

    void OnEnable()
    {
        eventSO.RegisterListener(this);
    }

    void OnDisable()
    {
        eventSO.UnregisterListener(this);
    }

    //Lance l'evenement Unity lié au script
    public void OnScriptableObjectEvent(InputAction.CallbackContext obj)
    {
        response.Invoke();
    }
}
