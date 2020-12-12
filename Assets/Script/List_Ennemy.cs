using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List_Ennemy : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    private int waveNumber;

    void OnValidate()
    {
        foreach(var wave in waves)
        {
            if (wave.nombreEnnemy.Length != wave.typeEnnemy.Length)
            {
                System.Array.Resize(ref wave.typeEnnemy, wave.nombreEnnemy.Length);
            }
        }
    }

    void LaunchWave()
    {
        for (var i=0; i<waves[waveNumber].nombreEnnemy.Length; i++)
        {
            for (var j=0; j<waves[waveNumber].nombreEnnemy[i]; j++)
            {
                Instantiate(waves[waveNumber].typeEnnemy[i], transform.position,Quaternion.identity);
            }
        }
        waveNumber++;
    }

    // Start is called before the first frame update
    void Start()
    {
        LaunchWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
