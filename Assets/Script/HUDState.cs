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

    public void OnStateChange(GameState newState)
    {
        txt.text = newState.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
