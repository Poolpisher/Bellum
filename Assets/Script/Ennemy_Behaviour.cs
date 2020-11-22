﻿using UnityEngine;
using UnityEngine.AI;

public class Ennemy_Behaviour : MonoBehaviour
{
    //Point de vie
    [SerializeField] private int health;
    //Argent du joueur
    [SerializeField] public static int gold;
    //destination de l'ennemi
    [SerializeField] private Transform destination;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            health = health - 2;
            gold = gold + 5;
            ScoreBehaviour.instance.AddScore(gold);
            if(health == 0)
            {
                Destroy(gameObject);
                gold = gold + 10;
                ScoreBehaviour.instance.AddScore(gold);
            }
        }
    }
}
