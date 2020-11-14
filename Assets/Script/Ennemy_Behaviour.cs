using UnityEngine;
using UnityEngine.AI;

public class Ennemy_Behaviour : MonoBehaviour
{
    //Vitesse du joueurPoint de vie
    [SerializeField] private int health;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //NavMeshAgent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
