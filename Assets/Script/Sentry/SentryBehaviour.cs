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
    //Layer des ennemies pour pouvoir trier ce qui est dans la range des tourelles
    [SerializeField] private LayerMask ennemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        //Récupération du canon de la tourelle
        canonTransform = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Remet le firstAgent a null pour éviter les erreurs une fois un firstAgent détruit
        NavMeshAgent firstAgent = null;
        //Récupère les ennemis qui entre en collision avec la range de la tourelle (2e enfant de la tourelle)
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, (transform.localScale.x * transform.GetChild(1).localScale.x)/2, ennemyLayer);
        //Pour chaque ennemi récupéré
        foreach (var hitCollider in hitColliders)
        {
            //Récupère le NavMeshAgent pour connaitre sa progression
            var agent = hitCollider.GetComponent<NavMeshAgent>();
            //Si aucun ennemi n'est désigné comme firstAgent, définit le premier ennemi comme FirstAgent
            if(firstAgent == null)
            {
                firstAgent = agent;
            }
            //Récupère le firstAgent le plus avancé
            else if(agent.GetPathRemainingDistance() < firstAgent.GetPathRemainingDistance())
            {
                //L'ennemi actuel devient le firstAgent
                firstAgent = agent;
            }
        }
        //Tire sur le FirstAgent
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
