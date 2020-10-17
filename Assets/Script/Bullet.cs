using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Orientation de la balle
    public Vector3 fixinputValue;
    //Vitesse de la balle
    [SerializeField] private int bulletSpeed;
    private new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //Déplacement de la balle
        rigidbody.AddForce(fixinputValue * bulletSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    void OnBecameInvisible()
    {
        //détruit la balle une fois hors de portée de la caméra
        Destroy(gameObject);
    }
}
