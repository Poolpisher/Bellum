using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public enum GameState
{
    Parabellum, Antebellum, Bellum
}

public class GameManager : MonoBehaviour
{
    public static GameState ActiveState;
    [SerializeField] private State_Event OnStateChange;
    public static GameManager Instance;

    //Lance la partie "Antebellum" avant la vague
    public void Antebellum(InputAction.CallbackContext obj)
    {
        ActiveState = GameState.Antebellum;
        OnStateChange.Invoke(GameState.Antebellum);
        StartCoroutine(CountdownAntebellum());
    }

    private IEnumerator CountdownAntebellum()
    {
        yield return new WaitForSeconds(4);
        OnStateChange.Invoke(GameState.Bellum);
    }

    private void Awake()
    {
        ActiveState = GameState.Parabellum;
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        OnStateChange.Invoke(ActiveState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
