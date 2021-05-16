using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SentryHealthBehaviour : MonoBehaviour
{
    public static SentryHealthBehaviour instance;
    TextMeshProUGUI txt;

    void OnEnable()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    //Met les HP à jour
    public void DisplayScore(int health)
    {
        txt.text = health.ToString() + "/10";
    }

    // Start is called before the first frame update
    void Awake()
    {
        //Récupere le texte du HUD
        txt = GetComponent<TextMeshProUGUI>();
    }
}
