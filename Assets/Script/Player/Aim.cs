using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public static Aim instance;
    private IMousePositionProvider mousePosition;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        mousePosition = GetComponent<IMousePositionProvider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Application de l'angle sur la rotation du joueur
        transform.rotation = Quaternion.AngleAxis(mousePosition.aimAngle, Vector3.down);
    }
}
