using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine;

//Création des 3 types de phases de jeu dans la classe GameState
public enum GameState
{
    Parabellum, Antebellum, Bellum
}

public class GameManager : MonoBehaviour
{
    //Durée de la vague antebellum
    [SerializeField] private int timerAntebellum;
    //Evenement Unity du script Vector3Event
    public static GameState activeState;
    //Evenement qui change le nom de lague dans le HUD et relance l'animation
    [SerializeField] private State_Event onStateChange;
    [SerializeField] private UnityEvent onBellum;
    //
    public static GameManager Instance;

    /// <summary>
    /// Lance la partie "Antebellum" avant la vague
    /// </summary>
    public void Antebellum(InputAction.CallbackContext obj)
    {
        activeState = GameState.Antebellum;
        onStateChange.Invoke(GameState.Antebellum);
        StartCoroutine(CountdownAntebellum());
    }
    // Lance le timer "Antebellum" avant la partie "Bellum"
    private IEnumerator CountdownAntebellum()
    {
        yield return new WaitForSeconds(timerAntebellum);
        onStateChange.Invoke(GameState.Bellum);
        onBellum.Invoke();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onStateChange.Invoke(activeState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
