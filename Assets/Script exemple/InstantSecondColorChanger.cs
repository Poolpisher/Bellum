using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSecondColorChanger : SecondColorChanger
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Change()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
