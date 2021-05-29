using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Projectile
    [SerializeField] private GameObject bulletPrefab;
    //Temps correspondant au dernier tir
    private float lastShoot;
    //Rigidbody
    private new Rigidbody rigidbody;
    public float actualTime;

    public static Shoot instance;
    void OnEnable()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private MousePosition mousePosition;
    void Awake()
    {
        mousePosition = GetComponent<MousePosition>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shooting()
    {
        //Calcul du temps lors du tir
        actualTime = Time.time;
        //Si le joueur peux tier et que le temps actuel est supérieur à celui du dernier tir + le temps minimum requis entre chaque tir
        //Création de la balle
        var createBullet = Instantiate(bulletPrefab, rigidbody.position, Quaternion.identity);
        //Orientation de la balle
        createBullet.GetComponent<Bullet>().fixinputValue = mousePosition.look;
        //Changement de la valeur du dernier tir
        lastShoot = actualTime;
    }
}
