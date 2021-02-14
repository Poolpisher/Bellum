using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        txt = GetComponent<TextMeshProUGUI>();
        //Animation + premier chiffre
        animator.Rebind();
        txt.text = "" + count;
    }

    // Update is called once per frame
    void Update()
    {
        if(canLaunchCountdown)
        {
        //StartCoroutine(Countdown());
        }
    }
    /*
    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        count--;
        animator.Rebind();
        txt.text = "" + count;
    }
    */
}
