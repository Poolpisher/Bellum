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
    //Si le joueur peux lancer la vague Antebellum
    public static bool canAntebellum = true;
    //Durée de la vague antebellum
    [SerializeField] private int timerAntebellum;
    //Evenement Unity du script Vector3Event
    public static GameState activeState;
    //Musique avec Antebellum
    public static AudioSource music;
    //Evenement qui change le nom de vague dans le HUD et relance l'animation
    [SerializeField] private State_Event onStateChange;
    [SerializeField] private UnityEvent onBellum;
    public static GameManager Instance;

    /// <summary>
    /// Lance la partie "Antebellum" avant la vague
    /// </summary>
    public void Parabellum(InputAction.CallbackContext obj)
    {
        //Passe en Parabellum
        activeState = GameState.Parabellum;
        onStateChange.Invoke(GameState.Parabellum);
    }
    public void Antebellum(InputAction.CallbackContext obj)
    {
        if(canAntebellum)
        {
        canAntebellum = false;
        //Passe en Antebellum
        activeState = GameState.Antebellum;
        onStateChange.Invoke(GameState.Antebellum);
        //Compte à rebours avant la partie Bellum
        StartCoroutine(CountdownAntebellum());
        }
    }
    // Lance le timer "Antebellum" avant la partie "Bellum"
    private IEnumerator CountdownAntebellum()
    {
        music.Play();
        //Compte à rebours
        yield return new WaitForSeconds(timerAntebellum);
        //Passe en Bellum
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
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
