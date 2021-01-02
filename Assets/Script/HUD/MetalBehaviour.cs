using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MetalBehaviour : MonoBehaviour
{
    //Ressource du joueur
    [SerializeField] private int metal;
    //valeur identique pour vérifier que le joueur a assez de ressources (script SentryManagement)
    [SerializeField] public static int toCompareMetal;
    //
    public static MetalBehaviour instance;
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
        metal += scoreToAdd;
        txt.text = metal.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Récupere le texte du HUD
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = metal.ToString();
    }

    void Update()
    {
        toCompareMetal = metal;
    }
}
