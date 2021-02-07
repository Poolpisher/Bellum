using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GoldBehaviour : MonoBehaviour
{
    //Ressource du joueur
    [SerializeField] private int gold;
    //valeur identique pour vérifier que le joueur a assez de ressources (script SentryManagement)
    [SerializeField] public static int toCompareGold;
    //
    public static GoldBehaviour instance;
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
    public void AddScore(int scoreToAdd)
    {
        gold += scoreToAdd;
        txt.text = gold.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Récupere le texte du HUD
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = gold.ToString();
    }

    void Update()
    {
        toCompareGold = gold;
    }
}
