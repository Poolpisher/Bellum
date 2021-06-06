using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedColorChanger : MonoBehaviour, IColorChanger
{
    public void Change()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void Test()
    {
        
    }
}
