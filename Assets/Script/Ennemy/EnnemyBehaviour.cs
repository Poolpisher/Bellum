using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    //Point de vie
    [SerializeField] private int health;
    //Score
    //Score qui sera additionné aux variables metalOnHit et metalOnDeath
    private int scoreToAdd;
    //Ressource récupérer lors d'un coup
    [SerializeField] private int metalOnHit;
    //Ressource récupérer lors de la mort d'un ennemie
    [SerializeField] private int metalOnDeath;
    //destination de l'ennemi
    [SerializeField] private Transform destination;
    //Agent de déplacement des ennemis
    private UnityEngine.AI.NavMeshAgent agent;
    //Ennemi le plus proche de la destination
    public static UnityEngine.AI.NavMeshAgent firstAgent;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //Par défaut l'agent le plus proche de la destination est le premier à apparaitre
        if (firstAgent == null)
        {
            firstAgent = agent;
        }
        //Donne la position de la destination pour que le NavMesh s'y rende automatiquement
        agent.SetDestination(destination.position);
    }
 
    // Update is called once per frame
    void Update()
    {
        if (firstAgent != null)
        {
            //Si la distance parcouru par l'ennemi actuel est plus petite que celle du firstAgent
            if (agent.GetPathRemainingDistance() < firstAgent.GetPathRemainingDistance())
            {
                //L'ennemi actuel devient le firstAgent
                firstAgent = agent;
            }
        }
        else
        {
            //L'ennemi actuel devient le firstAgent
            firstAgent = agent;
        }
    }

    /// <summary>
    /// Lorsque l'ennemie est touché, vérifie son état
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //Si c'est bien un projectile qui touche l'ennemie
        if (other.CompareTag("Bullet"))
        {
            //Détruit le projectile
            Destroy(other.gameObject);
            //Baisse la vie de l'ennemie
            health = health - 2;
            if (health > 0)
            {
                //Rajoute du metal à ScoreBehaviour
                MetalBehaviour.instance.AddScore(scoreToAdd + metalOnHit);
            }
            else if (health < 1)
            {
                //Détruit l'ennemie si sa vie atteind 0 ou moins et lance la fonction OnDestroy
                Destroy(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        //Rajoute du metal à ScoreBehaviour
        MetalBehaviour.instance.AddScore(scoreToAdd + metalOnDeath);
        firstAgent = null;
    }
}
