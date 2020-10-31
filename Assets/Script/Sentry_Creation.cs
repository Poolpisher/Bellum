using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry_Creation : MonoBehaviour
{

    [SerializeField] private GameObject Sentry;

    //Rigidbody
    private new Rigidbody rigidbody;

    private Vector3 spawnPos;

    public void ChangeSpawnPos(Vector3 newPos)
    {
        spawnPos = newPos;
    }

    public void Spawn()
    {
        Instantiate(Sentry, spawnPos, Quaternion.identity);
    }
    public void Destroy()
    {
        Destroy(Sentry);
    }

    // Start is called before the first frame update
    private void Start()
    {

    }
}
