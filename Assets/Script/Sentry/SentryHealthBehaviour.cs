using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SentryHealthBehaviour : MonoBehaviour
{
    //Ressource de la tourelle
    private int sentryHealth;
    private int maxSentryHealth;
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

    //Met le score à jour
    public void AddScore(int health)
    {
        sentryHealth += health;
        txt.text = sentryHealth.ToString() + "/10";
    }

    // Start is called before the first frame update
    void Start()
    {
        //Récupere le texte du HUD
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = sentryHealth.ToString();
    }

    void Update()
    {
        //sentryHealth = SentryBehaviour.sentryHealth;
    }
}
