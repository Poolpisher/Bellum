using UnityEngine.UI;
using UnityEngine;

public class BulletCountdown : MonoBehaviour
{
    public static int remainBullet;
    public static int maxBullet;
    [SerializeField] Text txt;

    public void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    public void Update()
    {
        txt.text = remainBullet + "/" + maxBullet;
    }
}
