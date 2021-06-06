using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    IColorChanger changer;

    [SerializeField] SecondColorChanger secondChanger;

    // Start is called before the first frame update
    void Start()
    {
        //changer = GetComponent<IColorChanger>();
        //changer.Change();
        secondChanger.Change();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
