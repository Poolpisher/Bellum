using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BulletCountdown : MonoBehaviour
{
    private int remainBullet;
    public static int maxBullet;
    TextMeshProUGUI txt;

    public void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        remainBullet = maxBullet;
        txt.text = remainBullet + "/" + maxBullet;
    }

    public void Shoot()
    {
        //décrémentation du nombre de balle restante
        remainBullet--;
        txt.text = remainBullet + "/" + maxBullet;
    }

    public void Reload()
    {
        remainBullet = maxBullet;
        txt.text = remainBullet + "/" + maxBullet;
    }
}
