using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Shop : MonoBehaviour
{    
    //Référence de l'arme du joueur
    [SerializeField] private PlayerGunSO playerStat;
    //Prix de l'améliorations du nombres de balles dans le chargeur
    [SerializeField] private int increaseMaxBulletPrice;
    //Nombres de balles à ajouter dans IncreaseMaxBullet
    [SerializeField] private int increaseMaxBulletToAdd;
    //Prix de l'améliorations de la vitesse de rechargement
    [SerializeField] private int shorterReloadPrice;
    //Vitesse de recharge à améliorer dans ShorterReload
    [SerializeField] private int shorterReloadToChange;

    //Améliorations du nombres de balles dans le chargeur
    public void IncreaseMaxBullet()
    {
        if(GoldBehaviour.toCompareGold >= increaseMaxBulletPrice)
        {
            //GoldBehaviour
            GoldBehaviour.instance.AddScore(-increaseMaxBulletPrice);
            //BulletCountdown
            BulletCountdown.maxBullet = BulletCountdown.maxBullet + increaseMaxBulletToAdd;
            BulletCountdown.instance.Reload();
            //PlayerGunSO
            playerStat.maxBullet = playerStat.maxBullet + increaseMaxBulletToAdd;
            //PlayerShoot (pour debug)
            PlayerShoot.instance.IncreaseMaxBullet();
            //Shop
            increaseMaxBulletPrice = increaseMaxBulletPrice + 20;
            increaseMaxBulletToAdd = increaseMaxBulletToAdd + 10;
        }
    }
    
    //Améliorations de la vitesse de rechargement
    public void ShorterReload()
    {
        if(GoldBehaviour.toCompareGold >= shorterReloadPrice)
        {
            //Control.myAnimator.speed = myAnimator.speed * shorterReloadToChange;
            //Control.waitForReloading = waitForReloading / shorterReloadToChange;

            //myAnimator * 2
            //waitForReloading / 2
                //https://docs.unity3d.com/ScriptReference/Animator-speed.html
            shorterReloadPrice = shorterReloadPrice + 10;
            shorterReloadToChange = shorterReloadToChange + 1;
        }
    }
    
    //Référence de la tourelle du joueur
    [SerializeField] private SentryGunSO sentryStat;
    //Prix de l'améliorations de la cadence de tir des tourelles
    [SerializeField] private int increaseSentryCooldownPrice;
    //Améliorations de la cadence de tir des tourelles
    [SerializeField] private int increaseSentryCooldown;
    //Prix de l'améliorations de la jauge d'usure des tourelles
    [SerializeField] private int increaseSentryLifePrice;
    //Améliorations de la jauge d'usure des tourelles
    [SerializeField] private int increaseSentryLife;

    public void SentryCooldown()
    {
        
    }
    public void SentryLife()
    {
        
    }
}
