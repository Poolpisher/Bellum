using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List_Ennemy : MonoBehaviour
{
    //Determine le nombres de vagues
    [SerializeField] private Wave[] waves;
    //Numéro de la vague
    private int waveNumber;

    //Vérifie que les cases nombreEnnemy et typeEnnemy du tableau sont de même taille
    void OnValidate()
    {
        foreach(var wave in waves)
        {
            //Vérification
            if (wave.nombreEnnemy.Length != wave.typeEnnemy.Length)
            {
                //Changement des tableaux
                System.Array.Resize(ref wave.typeEnnemy, wave.nombreEnnemy.Length);
            }
        }
    }

    void LaunchWave()
    {
        //Boucle for qui détermine le nombre et le type d'ennemie par la taille des tableaux
        for (var i=0; i<waves[waveNumber].nombreEnnemy.Length; i++)
        {
            //Boucle for pour créer tous les ennemies 1 par 1 en fonction de la case nombreEnnemy des tableaux
            for (var j=0; j<waves[waveNumber].nombreEnnemy[i]; j++)
            {
                //Créer les ennemies à la position du générateur d'ennemie
                Instantiate(waves[waveNumber].typeEnnemy[i], transform.position,Quaternion.identity);
            }
        }
        //Change le numéro de la vague actuelle
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
