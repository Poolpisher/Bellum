using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;

public class SentryManagement : MonoBehaviour
{
    [SerializeField] private GameObject Sentry;
    //Prix de construction de la tourelle
    [SerializeField] private int metalToCreate;
    //Prix de construction de la tourelle
    [SerializeField] private int metalToRepair;
    //Rigidbody
    private new Rigidbody rigidbody;
    //Stock la plateforme selectionné en dernier
    private Transform lastClickedPlateform;

    [SerializeField] private UnityEvent healthBarActive;
    //Bouton du HUD tourelle
    [SerializeField] private GameObject createButton;
    [SerializeField] private GameObject destroyButton;


    //Reselectionne la derniere plateforme cliquer dans ce script via la fonction Click du script Control (onClickPlateform.Invoke())
    public void ChangeLastClickedPlatform(Transform newPlatform)
    {
        lastClickedPlateform = newPlatform;
    }

    private void OnEnable()
    {
        //Activation des controles
        /*
        InputManager.instance.playerInput.Action.HUDshortcut.performed += Create;
        InputManager.instance.playerInput.Action.HUDshortcut.performed += Destroy;
        */
    }

    /// <summary>
    /// Bouton Create du HUD pour placer une tourelle
    /// </summary>
    public void Create(/*InputAction.CallbackContext obj*/)
    {
        //Vérifie qu'une tourelle n'est pas déjà placée et que le joueur a assez de metal
        if (lastClickedPlateform.childCount == 0 && MetalBehaviour.toCompareMetal >= metalToCreate)
        {
            //retire le prix de la construction de la tourelle en metal
            MetalBehaviour.instance.AddScore(-metalToCreate);
            //Créer la tourelle
            var createSentry = Instantiate(Sentry, lastClickedPlateform.position, Quaternion.identity, lastClickedPlateform);
            healthBarActive.Invoke();
            //Récupère la range de la tourelle
            Click.getRange = createSentry.transform.GetChild(1).gameObject;
            //Affiche la range de la tourelle
            Click.getRange.SetActive(true);
        }
    }

    /// <summary>
    /// Bouton Destroy du HUD pour retirer une tourelle
    /// </summary>
    public void Destroy(/*InputAction.CallbackContext obj*/)
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
        MetalBehaviour.instance.AddScore(metalToCreate);
        //Affiche le bouton create et désaffiche le bouton destroy du HUD des tourelles
        createButton.SetActive(true);
        destroyButton.SetActive(false);
    }

    public void Repair()
    {
        if (MetalBehaviour.toCompareMetal >= metalToRepair)
        {
            //retire le prix de la construction de la tourelle en metal
            MetalBehaviour.instance.AddScore(-metalToRepair);
            //Lance la fonction de réparation de la tourelle
            lastClickedPlateform.GetComponentInChildren<SentryBehaviour>().Repaired();
        }
    }
}
