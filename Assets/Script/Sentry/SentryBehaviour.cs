using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class SentryBehaviour : MonoBehaviour
{
    //
    private Vector3 look;
    //Projectile
    [SerializeField] private GameObject bulletPrefab;
    //
    private Transform canonTransform;
    //Temps entre 2 balles
    [SerializeField] private float shootTimer;
    //Temps correspondant au dernier tir
    private float lastShoot;
    //
    [SerializeField] private float rangeShoot;

    // Start is called before the first frame update
    void Start()
    {
        canonTransform = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (rangeShoot < Vector3.Distance(canonTransform.position, EnnemyBehaviour.firstAgent.transform.position))
        {
            if (EnnemyBehaviour.firstAgent != null)
            {
                //Calcul du temps lors du tir
                var actualTime = Time.time;

                //Faire en sorte que les tourelles regardent l'ennemie le plus avancé de la carte (le firstAgent de EnnemyBehaviour)
                transform.LookAt(EnnemyBehaviour.firstAgent.transform.position);

                if (actualTime > lastShoot + shootTimer)
                {
                    //Création de la balle
                    var createBullet = Instantiate(bulletPrefab, canonTransform.position, Quaternion.identity);
                    var look = (EnnemyBehaviour.firstAgent.transform.position - canonTransform.position).normalized;
                    //Orientation de la balle
                    createBullet.GetComponent<Bullet>().fixinputValue = look;
                    //Changement de la valeur du dernier tir
                    lastShoot = actualTime;
                }
            
            }
        }
        
    }
}
