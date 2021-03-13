using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestinationBehaviour : MonoBehaviour
{
    //Liste des ennemies présents sur le collider destination
    private List<Collider> ennemiesOnDestination;
    //Event unity en cas d'entrer/sortie du collider
    [SerializeField] private UnityEvent onTriggerEnterEvent;
    [SerializeField] private UnityEvent onTriggerExitEvent;
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

    private void Start()
    {
        ennemiesOnDestination = new List<Collider>();
    }

    //Si le collider est trigger
    void OnTriggerEnter(Collider other)
    {
        //Si le collider qui trigger est bien un ennemy
        if(!other.CompareTag ("Ennemy"))
            return;
        //Rajoute l'ennemi à la liste
        ennemiesOnDestination.Add(other);
        //Si au moins 1 ennemie est présent
        if(ennemiesOnDestination.Count >= 1)
        {
            //Compte à rebours
            onTriggerEnterEvent.Invoke();
        }
    }

    //Si le collider n'est plus trigger par 1 élément
    public void OnTriggerExit(Collider other)
    {
        //Si le collider qui trigger est bien un ennemy
        if(!other.CompareTag ("Ennemy"))
            return;
        //Si l'ennemi qui vient d'être destroy était bien dans la liste
        if(ennemiesOnDestination.Contains(other))
        {
            //Retire l'ennemi de la liste
            ennemiesOnDestination.Remove(other);
        }
        //Si aucun ennemie n'est présent
        if(ennemiesOnDestination.Count == 0)
        {
            //Annulation du compte à rebours
            onTriggerExitEvent.Invoke();
        }
    }
}
