using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class List_Ennemy : MonoBehaviour
{
    //Timer avant la vague
    [SerializeField] private float originalTime;
    [SerializeField] private float time = 1;
    [SerializeField] private bool canAntebellum;
    //Animator
    private Animator myAnimator;
    //Affiche/Désaffiche le HUD
    [SerializeField] private UnityEvent hudBellum;
    [SerializeField] private UnityEvent hudParabellum;
    [SerializeField] private UnityEvent hudAntebellum;
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

    // Start is called before the first frame update
    void Start()
    {

    }
    
    void Parabellum()
    {
        //Parabellum
        //Met le HUD à jour
        hudParabellum.Invoke();
    }
    public void TimerAntebellum()
    {
        //Relance le timer
        time = originalTime;
        //Permet de ne pas lancer le timer tout le temps
        canAntebellum = true;
    }
    public void Antebellum()
    {
        //Met le HUD à jour
        hudAntebellum.Invoke();
        //Diminue le timer
        time -= Time.deltaTime;
    }
    void Bellum()
    {
        canAntebellum = false;
        //Met le HUD à jour
        hudBellum.Invoke();
        //Lance la vague
        LaunchWave();
            //Repasser à Parabellum une fois la vague terminée
    }

    // Update is called once per frame
    void Update()
    {
        //Début Timer avant la vague: Antebellum
        if (time > 0 && canAntebellum)
        {
            Antebellum();
        }
        //La vague: Bellum
        else if (time <= 0)
        {
            Bellum();
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
}
