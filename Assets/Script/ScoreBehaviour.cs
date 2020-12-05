using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    public static ScoreBehaviour instance;
    [SerializeField] private int score;
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
        score += scoreToAdd;
        txt.text = score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = score.ToString();
    }
}
