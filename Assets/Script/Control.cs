using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Control : MonoBehaviour
{
    //Vitesse du joueur
    [SerializeField] private int speed;
    //Si le joueur peux tirer
    [SerializeField] private bool canShoot = true;
    //Projectile
    [SerializeField] private GameObject bulletPrefab;
    //Vitesse du joueur
    [SerializeField] private LayerMask layerMask;
    //Orientation du joueur
    private Vector2 inputValue;
    private Vector3 inputValue3D;
    //HUD
    private GameObject HUD;
    //Caméra
    private Camera cam;
    //Permet de récupérer la position de la souris
    private Event currentEvent;
    //???
    private Vector3 look;
    private Vector3 point;
    //Position de la souris
    private Vector2 mousePos;
    //Control
    private Player playerInput;

    private Coroutine isShooting;
    private new Rigidbody rigidbody;

    //Activation des controles
    private void OnEnable()
    {
        playerInput = new Player();
        playerInput.Enable();
        playerInput.Action.Move.performed += Move;
        playerInput.Action.Move.canceled += Stop;
        playerInput.Action.Shoot.performed += Shoot;
        playerInput.Action.Shoot.canceled += StopShoot;
        playerInput.Action.MouseClick.performed += Click;
        playerInput.Action.MousePosition.performed += MousePosition;
    }

    //tir
    void Shoot(InputAction.CallbackContext obj)
    {
        if (canShoot == true)
        {
            canShoot = false;
            //Créer le projectile
            var createBullet = Instantiate(bulletPrefab, rigidbody.position, Quaternion.identity);
            createBullet.GetComponent<Bullet>().fixinputValue = look;
        }
        isShooting = StartCoroutine(TirContinu());
    }

    private void StopShoot(InputAction.CallbackContext obj)
    {
        StopCoroutine(isShooting);
    }

    private IEnumerator TirContinu()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            var createBullet = Instantiate(bulletPrefab, rigidbody.position, Quaternion.identity);
            createBullet.GetComponent<Bullet>().fixinputValue = look;
            canShoot = true;
        }
    }

    //Déplacement
    private void Move(InputAction.CallbackContext obj)
    {
        inputValue = obj.ReadValue<Vector2>();
        inputValue3D = new Vector3(inputValue.x, 0, inputValue.y);
    }
    //Arret du déplacement
    private void Stop(InputAction.CallbackContext obj)
    {
        inputValue3D = Vector2.zero;
    }

    private void Click(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cam.transform.position, point - cam.transform.position, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(cam.transform.position, point - cam.transform.position, Color.yellow);
            Debug.Log("Did Hit");
                //Le HUD ne s'affiche pas
            //active canvas HUD
            HUD.SetActive(true);
        }
        else
        {
            Debug.DrawRay(cam.transform.position, point - cam.transform.position, Color.white);
            Debug.Log("Did not Hit");
            //Debug.Break();

            //désactive canvas HUD
            HUD.SetActive(false);
        }
    }

    private void MousePosition(InputAction.CallbackContext obj)
    {
        mousePos = obj.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main;
        //Enregistre les éléments du HUD pour les supprimer/réafficher via les variables
        HUD = GameObject.FindGameObjectWithTag("HUD");
    }
    void Update()
    {
        //Transformation de la position de la souris dans le monde
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, (transform.position - cam.transform.position).magnitude));
        //Distance entre le joueur et la souris et Changement de l'orientation de la balle en fonction de la souris
        look = (point - transform.position).normalized;
        //Calcul de l'angle a partir de "look"
        var aimAngle = Vector3.SignedAngle(Vector3.forward , look, Vector3.down);
        //Application de l'angle sur la rotation du joueur
        transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.down);
    }

// Update is called once per frame
void FixedUpdate()
    {
        //Mise a jour de la vitesse
        rigidbody.velocity = inputValue3D * speed;
    }
}
