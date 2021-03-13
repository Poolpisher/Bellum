using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using UnityEngine;


public class Countdown : MonoBehaviour
{
    Animator animator;
    TextMeshProUGUI txt;
    //Chiffre à afficher
    [SerializeField]private int count = 5;
    //Peux lancer le compte à rebours
    public static bool canLaunchCountdown;
    //Event unity du compte à rebours
    [SerializeField] private UnityEvent onCountdownEnding;

    void Awake()
    {
        animator = GetComponent<Animator>();
        txt = GetComponent<TextMeshProUGUI>();
        //Animation + premier chiffre
        txt.text = "" + count;
    }

    //Sur apparition du compte à rebours
    void OnEnable()
    {
        //Reset le compte à rebours
        count = 5;
        txt.text = "" + count;
        //Lance le compte à rebours
        StartCoroutine(changeCountdown());
    }
    //Compte à rebours
    public IEnumerator changeCountdown()
    {
        while(count > 0)
        {
        yield return new WaitForSeconds(1);
        count--;
        txt.text = "" + count;
        }
        //Lance l'écran failure
        onCountdownEnding.Invoke();
    }
}
