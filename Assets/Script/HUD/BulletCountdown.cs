using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BulletCountdown : MonoBehaviour
{
    //Balles restantes
    private int remainBullet;
    //Nombre de balles max
    public static int maxBullet;
    TextMeshProUGUI txt;
    public static BulletCountdown instance;

    void OnEnable()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public void Start()
    {
        //Récupere le texte du HUD
        txt = GetComponent<TextMeshProUGUI>();
        //Remet les variables à niveau
        remainBullet = maxBullet;
        RefreshHUD();
    }

    public void Shoot()
    {
        //décrémentation du nombre de balle restante
        remainBullet--;
        RefreshHUD();
    }

    public void Reload()
    {
        //Remet les variables à niveau
        remainBullet = maxBullet;
        RefreshHUD();
    }

    private void RefreshHUD()
    {
        //Mise à jour du score dans le HUD
        txt.text = remainBullet + "/" + maxBullet;
    }
}
