using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    public static ScoreBehaviour instance;
    TextMeshProUGUI txt;

    void OnEnable()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public void AddScore(int scoreToAdd)
    {
        txt.text = scoreToAdd.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = Ennemy_Behaviour.gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
