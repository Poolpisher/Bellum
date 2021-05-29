using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;

[CreateAssetMenu]
public class PlayerGunSO : GunSO
{
    public int reloadTimer;
    public int maxBullet;
    //Layer mask pour ouvrir les différents HUD
    public LayerMask HUDtourelles;
    //Récupération des component des boutons du HUD pour éviter de tirer en cliquant dessus (voir Shoot())
    
    public bool isClickingHUD(EventSystem eventSystemHUDtourelles, Vector2 mousePos, GraphicRaycaster raycasterHUDtourelles)
    {
        //Vérifie si le clique collisione avec un bouton du HUD
        bool raycastResult = false;

        //Set up the new Pointer Event
        var pointerEventDataHUDtourelles = new PointerEventData(eventSystemHUDtourelles);
        //Set the Pointer Event Position to that of the mouse position
        pointerEventDataHUDtourelles.position = mousePos;
        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();
        //Raycast using the Graphics Raycaster and mouse click position
        raycasterHUDtourelles.Raycast(pointerEventDataHUDtourelles, results);
        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            //Vérifie si le clique collisione avec un objet ayant le tag "Button"
            raycastResult = result.gameObject.CompareTag("Button");
            //Permet d'arrêter la verification si un bouton a été trouvé
            if (raycastResult)
            {
                break;
            }
        }
        //Permet de tirer si le joueur ne clique pas sur un bouton
        return raycastResult;
    }
}
