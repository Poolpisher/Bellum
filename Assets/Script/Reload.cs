using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Reload : MonoBehaviour
{
    TextMeshProUGUI txt;
    Animator myAnimator;

    public void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }
    public void Reloading()
    {
        myAnimator.SetBool("isReloading", true);
    }
}