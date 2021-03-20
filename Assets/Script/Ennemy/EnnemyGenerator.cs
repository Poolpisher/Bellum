using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class EnnemyGenerator : MonoBehaviour
{
    //Determine le nombres de vagues
    [SerializeField] private Wave[] waves;
    //Numéro de la vague
    private int waveNumber;
    //Liste des ennemies restant sur une vague
    private List<GameObject> remainingEnnemies;
    //Vérifie si tous les ennemies d'une vague sont apparues
    private bool hasFinishedSpawning = false;
    //Singleton
    public static EnnemyGenerator instance;
    //Event unity en cas de réussite
    [SerializeField] private UnityEvent onFinishingAllWaves;

    /// <summary>
    /// Vérifie que les cases nombreEnnemy et typeEnnemy du tableau sont de même taille
    /// </summary>
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

    //Retire l'ennemie qui vient d'être détruit de la liste
    public void removeFromList(GameObject toRemove)
    {
        //Retire l'ennemie de la liste
        remainingEnnemies.Remove(toRemove);
        //Si c'est le dernier ennemi qui a été détruit
        if(hasFinishedSpawning && remainingEnnemies.Count == 0)
        {
            //Change le numéro de la vague actuelle
            waveNumber++;
            //Repasse le jeu en Parabellum
            GameManager.Instance.onStateChange.Invoke(GameState.Parabellum);
            GameManager.music.Stop();

            //Si le joueur à terminer toutes les vagues
            if(waveNumber == waves.Length)
            {
                //Lance l'écran de victoire
                onFinishingAllWaves.Invoke();
            }

            //Permet au joueur de lancer la prochaine vague
            GameManager.canAntebellum = true;
            hasFinishedSpawning = false;
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    void Start()
    {
        remainingEnnemies = new List<GameObject>();
    }
    
    /// <summary>
    /// Instantie les ennemies d'une vague avant de passer à la suivante
    /// </summary>
    public void LaunchWave()
    {
        StartCoroutine(WaitForNextEnnemy());
    }

    //Temps d'attente entre chaque ennemis
    public IEnumerator WaitForNextEnnemy()
    {
        //Boucle for qui détermine le nombre et le type d'ennemie par la taille des tableaux
        for (var i=0; i<waves[waveNumber].nombreEnnemy.Length; i++)
        {
            //Boucle for pour créer tous les ennemies 1 par 1 en fonction de la case nombreEnnemy des tableaux
            for (var j=0; j<waves[waveNumber].nombreEnnemy[i]; j++)
            {
                //Créer les ennemies à la position du générateur d'ennemie
                var createEnnemies = Instantiate(waves[waveNumber].typeEnnemy[i], transform.position,Quaternion.identity);
                remainingEnnemies.Add(createEnnemies);
                //attends 1 secondes
                yield return new WaitForSeconds(1);
            }
        }
        //Tout les ennemies de la vague sont apparues
        hasFinishedSpawning = true;
    }
}
