using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Reload : MonoBehaviour
{
    TextMeshProUGUI txt;
    Animator myAnimator;
    //texte à animer pour la recharge
    public void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }
    //Animation de recharge
    public void Reloading()
    {
        myAnimator.SetBool("isReloading", true);
    }
}