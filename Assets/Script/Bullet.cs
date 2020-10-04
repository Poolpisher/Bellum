using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Orientation de la balle
    public Vector2 fixinputValue;
    private new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //Limitation de l'orientation de la balle 
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(fixinputValue);
        //Déplacement de la balle
            //Multiplier par 1 pour ralentir la balle pour l'instant mais à changer plus tard
        rigidbody.AddForce(fixinputValue * 1);
    }
    void OnBecameInvisible()
    {
        //détruit la balle une fois hors de portée de la caméra
        Destroy(gameObject);
    }
}
