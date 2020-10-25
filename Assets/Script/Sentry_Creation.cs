using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry_Creation : MonoBehaviour
{

    [SerializeField] private GameObject Sentry;
    //Rigidbody
    private new Rigidbody rigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        //StartCoroutine(Create());
    }
    /*
    private IEnumerator Create()
    {
        var create = Instantiate(Sentry, rigidbody.position, Quaternion.identity);
    }
    */
}
