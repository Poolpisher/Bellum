using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry_Management : MonoBehaviour
{
    [SerializeField] private GameObject Sentry;
    //Prix de construction de la tourelle
    [SerializeField] private int metal;
    //Rigidbody
    private new Rigidbody rigidbody;

    private Transform lastClickedPlateform;
    //Reselectionne la derniere plateforme cliquer dans ce script via la fonction Click du script Control (onClickPlateform.Invoke())
    public void ChangeLastClickedPlatform(Transform newPlatform)
    {
        lastClickedPlateform = newPlatform;
    }
    //Bouton Create
    public void Create()
    {
        Instantiate(Sentry, lastClickedPlateform.position, Quaternion.identity, lastClickedPlateform);
        //retire le prix de la construction de la tourelle en metal
        ScoreBehaviour.instance.AddScore(-metal);
    }
    //Bouton Destroy
    public void Destroy()
    {
        //Si la plateforme selectionné n'a qu'un enfant
        if (lastClickedPlateform.childCount == 0)
            return;
        //Selectionne le dernier enfant de la plateforme (donc obligatoirement la tourelle)
        var Index = lastClickedPlateform.childCount - 1;
        var Sentry = lastClickedPlateform.GetChild(Index);
        //Détruit la tourelle
        Destroy(Sentry.gameObject);
        //Récupere le prix original de construction de la tourelle en metal
        ScoreBehaviour.instance.AddScore(metal);
    }
}
