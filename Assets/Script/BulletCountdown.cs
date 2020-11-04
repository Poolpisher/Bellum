using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BulletCountdown : MonoBehaviour
{
    public static int remainBullet;
    public static int maxBullet;
    TextMeshProUGUI txt;

    public void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void Update()
    {
        txt.text = remainBullet + "/" + maxBullet;
    }
}
