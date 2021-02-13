using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryManagement : MonoBehaviour
{
    [SerializeField] private GameObject Sentry;
    //Prix de construction de la tourelle
    [SerializeField] private int metal;
    //Rigidbody
    private new Rigidbody rigidbody;
    //Stock la plateforme selectionné en dernier
    private Transform lastClickedPlateform;
    //Bouton du HUD tourelle
    [SerializeField] private GameObject createButton;
    [SerializeField] private GameObject destroyButton;

    //Reselectionne la derniere plateforme cliquer dans ce script via la fonction Click du script Control (onClickPlateform.Invoke())
    public void ChangeLastClickedPlatform(Transform newPlatform)
    {
        lastClickedPlateform = newPlatform;
    }

    /// <summary>
    /// Bouton Create du HUD pour placer une tourelle
    /// </summary>
    public void Create()
    {
        //Vérifie qu'une tourelle n'est pas déjà placée et que le joueur a assez de metal
        if (lastClickedPlateform.childCount == 0 && MetalBehaviour.toCompareMetal >= metal)
        {
            //retire le prix de la construction de la tourelle en metal
            MetalBehaviour.instance.AddScore(-metal);
            var createSentry = Instantiate(Sentry, lastClickedPlateform.position, Quaternion.identity, lastClickedPlateform);
            Control.getRange = createSentry.transform.GetChild(1).gameObject;
            //Affiche le bouton destroy et désaffiche le bouton create du HUD des tourelles
            createButton.SetActive(false);
            destroyButton.SetActive(true);
        }
    }

    /// <summary>
    /// Bouton Destroy du HUD pour retirer une tourelle
    /// </summary>
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
        MetalBehaviour.instance.AddScore(metal);
        //Affiche le bouton create et désaffiche le bouton destroy du HUD des tourelles
        createButton.SetActive(true);
        destroyButton.SetActive(false);
    }
}
