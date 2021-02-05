using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class SentryBehaviour : MonoBehaviour
{
    //Projectile
    [SerializeField] private GameObject bulletPrefab;
    //Position de départ de la balle (les canons)
    private Transform canonTransform;
    //Temps entre 2 balles
    [SerializeField] private float shootTimer;
    //Temps correspondant au dernier tir
    private float lastShoot;
    //Distance de tir maximale de la tourelle
    [SerializeField] private float rangeShoot;
    //Distance entre le firstAgent et les canons de la tourelle dans la fonction tir
    private Vector3 look;

    // Start is called before the first frame update
    void Start()
    {
        canonTransform = transform.GetChild(0);
        lastShoot = 0;
    }

    // Update is called once per frame
    void Update()
    {
    //Fonction de tir de la tourelle
        //Si la tourelle à la portée suffisante (rangeShoot) pour tirer sur le firstAgent
        if (rangeShoot < Vector3.Distance(canonTransform.position, EnnemyBehaviour.firstAgent.transform.position))
        {
            //Si un firstAgent est bien présent
            if (EnnemyBehaviour.firstAgent != null)
            {
                //Calcul du temps lors du tir
                var actualTime = Time.time;

                //Faire en sorte que les tourelles regardent l'ennemie le plus avancé de la carte (le firstAgent de EnnemyBehaviour)
                transform.LookAt(EnnemyBehaviour.firstAgent.transform.position);

                //Permet d'instaurer le cooldown entre 2 tir
                if (actualTime > lastShoot + shootTimer)
                {
                    //Création de la balle
                    var createBullet = Instantiate(bulletPrefab, canonTransform.position, Quaternion.identity);
                    //Distance entre le firstAgent et les canons de la tourelle
                    var look = (EnnemyBehaviour.firstAgent.transform.position - canonTransform.position).normalized;
                    //Orientation de la balle
                    createBullet.GetComponent<Bullet>().fixinputValue = look;
                    //Changement de la valeur du dernier tir
                    lastShoot = actualTime;
                }
            }
            else
            {
            Debug.Log("Coucou");
            }
        }
        
    }
}
