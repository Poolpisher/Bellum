using UnityEngine;
using UnityEngine.AI;

public class Ennemy_Behaviour : MonoBehaviour
{
    //Point de vie
    [SerializeField] private int health;
    //Ressource du joueur
    [SerializeField] private int metal;
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
            metal = metal + 5;
            ScoreBehaviour.instance.AddScore(metal);
            if(health == 0)
            {
                Destroy(gameObject);
                metal = metal + 10;
                ScoreBehaviour.instance.AddScore(metal);
            }
        }
    }
}
