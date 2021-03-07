using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestinationBehaviour : MonoBehaviour
{
    //Ennemies présent sur le collider destination
    private int ennemiesOnDestination;
    //Event unity en cas d'entrer/sortie du collider
    [SerializeField] private UnityEvent onTriggerEnter;
    [SerializeField] private UnityEvent onTriggerExit;
    //Singleton
    public static DestinationBehaviour instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    //Si le collider est trigger
    void OnTriggerEnter(Collider other)
    {
        //Si le collider qui trigger est bien un ennemy
        if(!other.CompareTag ("Ennemy"))
            return;
        ennemiesOnDestination++;
        //Si au moins 1 ennemie est présent
        if(ennemiesOnDestination == 1)
        {
            //Compte à rebours
            onTriggerEnter.Invoke();
        }
    }

    //Si le collider n'est plus trigger par 1 élément
    public void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag ("Ennemy"))
            return;
        ennemiesOnDestination--;
        //Si aucun ennemie n'est présent
        if(ennemiesOnDestination == 0)
        {
            //Annulation du compte à rebours
            onTriggerExit.Invoke();
        }
    }
}
