using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    //
    public static ScoreBehaviour instance;

    [SerializeField] private int metal;
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
}
