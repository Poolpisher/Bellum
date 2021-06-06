using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Référence de l'arme du joueur
    [SerializeField] private GunSO gunSO;
    //Temps correspondant au dernier tir
    protected float lastShoot;
    //Rigidbody
    protected new Rigidbody rigidbody;

    protected IMousePositionProvider mousePosition;
    void Awake()
    {
        mousePosition = GetComponent<IMousePositionProvider>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Shooting()
    {
        //Création de la balle
        var createBullet = Instantiate(gunSO.bullet, rigidbody.position, Quaternion.identity);
        //Orientation de la balle
        createBullet.GetComponent<Bullet>().fixinputValue = mousePosition.look;
        //Changement de la valeur du dernier tir
        lastShoot = Time.time;
    }
}
