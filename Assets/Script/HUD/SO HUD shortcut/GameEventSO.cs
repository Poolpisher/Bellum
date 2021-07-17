using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEventSO : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    //Permet de lancer l'event dans "GameEventListener" via un raccourci clavier
    private UnityEngine.InputSystem.InputAction.CallbackContext obj;

    public void Raise()
    {
        foreach(var listener in listeners)
        {
            listener.OnScriptableObjectEvent();
        }
    }

    public void RegisterListener(GameEventListener gameEventListener)
    {
        listeners.Add(gameEventListener);
    }

    public void UnregisterListener(GameEventListener gameEventListener)
    {
        listeners.Remove(gameEventListener);
    }
}