using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry_Management : MonoBehaviour
{
    [SerializeField] private GameObject Sentry;
    [SerializeField] private int metal;
    //Rigidbody
    private new Rigidbody rigidbody;

    private Transform lastClickedPlateform;

    public void ChangeLastClickedPlatform(Transform newPlatform)
    {
        lastClickedPlateform = newPlatform;
    }

    public void Create()
    {
        Instantiate(Sentry, lastClickedPlateform.position, Quaternion.identity, lastClickedPlateform);
        ScoreBehaviour.instance.AddScore(-metal);
    }

    public void Destroy()
    {
        if (lastClickedPlateform.childCount == 0)
            return;
        
        var Index = lastClickedPlateform.childCount - 1;
        var Sentry = lastClickedPlateform.GetChild(Index);
        Destroy(Sentry.gameObject);
        ScoreBehaviour.instance.AddScore(metal);
    }
}