using TMPro;
using UnityEngine;

public class HUDState : MonoBehaviour
{
    TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Change le texte de la vague via le script GameManager
    /// </summary>
    public void OnStateChange(GameState newState)
    {
        txt.text = newState.ToString();
    }
}
