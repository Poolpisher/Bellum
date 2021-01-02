using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nouveau type de variable applicable aux autres script qui contient les 2 tableaux des ennemies (type et nombre)
[System.Serializable]
public class Wave
{
    public int[] nombreEnnemy;
    public GameObject[] typeEnnemy;
}
