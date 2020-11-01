﻿using System.Collections;
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
        Instantiate(Sentry, spawnPos, transform.rotation * Quaternion.Euler(270f, 0f, 0f));
    }
    public void Destroy()
    {
        Destroy(Sentry);
    }
}
