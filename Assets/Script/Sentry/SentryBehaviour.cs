using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnnemyBehaviour.firstAgent != null)
        {
            //Faire en sorte que les tourelles regardent l'ennemie le plus avancé de la carte (le firstAgent de EnnemyBehaviour)
            transform.LookAt(EnnemyBehaviour.firstAgent.transform.position);
        }
    }
}
