using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Application de l'angle sur la rotation du joueur
        //transform.rotation = Quaternion.AngleAxis(mousePosition.aimAngle, Vector3.down);
        transform.LookAt(target);
    }
}
