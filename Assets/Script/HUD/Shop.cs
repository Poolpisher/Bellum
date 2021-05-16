using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Shop : MonoBehaviour
{    
    //Prix de l'améliorations du nombres de balles dans le chargeur
    [SerializeField] private int increaseMaxBulletPrice;
    //Nombres de balles à ajouter dans IncreaseMaxBullet
    [SerializeField] private int increaseMaxBulletToAdd;
    //Prix de l'améliorations de la vitesse de rechargement
    [SerializeField] private int shorterReloadPrice;
    //Vitesse de recharge à améliorer dans ShorterReload
    [SerializeField] private int shorterReloadToChange;

    //Améliorations du nombres de balles dans le chargeur
    void IncreaseMaxBullet(InputAction.CallbackContext obj)
    {
        if(GoldBehaviour.toCompareGold >= increaseMaxBulletPrice)
        {
            //Control.maxBullet = maxBullet + increaseMaxBulletToAdd;
            increaseMaxBulletPrice = increaseMaxBulletPrice + 10;
            increaseMaxBulletToAdd = increaseMaxBulletToAdd + 10;
        }
    }
    
    //Améliorations de la vitesse de rechargement
    void ShorterReload(InputAction.CallbackContext obj)
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
    
    //Prix de l'améliorations de la cadence de tir des tourelles
    [SerializeField] private int increaseSentryCooldownPrice;
    //Améliorations de la cadence de tir des tourelles
    [SerializeField] private int increaseSentryCooldown;
    //Prix de l'améliorations de la jauge d'usure des tourelles
    [SerializeField] private int increaseSentryLifePrice;
    //Améliorations de la jauge d'usure des tourelles
    [SerializeField] private int increaseSentryLife;

    void SentryCooldown(InputAction.CallbackContext obj)
    {
        
    }
    void SentryLife(InputAction.CallbackContext obj)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
