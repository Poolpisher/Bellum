﻿using UnityEngine;
using UnityEngine.AI;

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
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Donne la position de la destination pour que le NavMesh s'y rende automatiquement
        agent.SetDestination(destination.position);
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
            else if(health < 1)
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
    }
}