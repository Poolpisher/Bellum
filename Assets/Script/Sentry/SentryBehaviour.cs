using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;
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

    [SerializeField] private LayerMask ennemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        canonTransform = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent firstAgent = null;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, (transform.localScale.x * transform.GetChild(1).localScale.x)/2, ennemyLayer);
        foreach (var hitCollider in hitColliders)
        {
            var agent = hitCollider.GetComponent<NavMeshAgent>();
            if(firstAgent == null)
            {
                firstAgent = agent;
            }
            else if(agent.GetPathRemainingDistance() < firstAgent.GetPathRemainingDistance())
            {
                //L'ennemi actuel devient le firstAgent
                firstAgent = agent;
            }
        }
        Shoot(firstAgent);
    }

    void Shoot(NavMeshAgent firstAgent)
    {
    //Fonction de tir de la tourelle
        //Si un firstAgent est bien présent
        if (firstAgent == null)
        {
            return;
        }
        //Si la tourelle à la portée suffisante (rangeShoot) pour tirer sur le firstAgent
        if (rangeShoot < Vector3.Distance(canonTransform.position, firstAgent.transform.position))
        {
            //Calcul du temps lors du tir
            var actualTime = Time.time;

            //Faire en sorte que les tourelles regardent l'ennemie le plus avancé de la carte (le firstAgent de EnnemyBehaviour)
            transform.LookAt(firstAgent.transform.position);

            //Permet d'instaurer le cooldown entre 2 tir
            if (actualTime > lastShoot + shootTimer)
            {
                //Création de la balle
                var createBullet = Instantiate(bulletPrefab, canonTransform.position, Quaternion.identity);
                //Distance entre le firstAgent et les canons de la tourelle
                var look = (firstAgent.transform.position - canonTransform.position).normalized;
                //Orientation de la balle
                createBullet.GetComponent<Bullet>().fixinputValue = look;
                //Changement de la valeur du dernier tir
                lastShoot = actualTime;
            }
        }
    }
}
