using UnityEngine;
using UnityEngine.Events;

//Créer des évenements pour les autres scripts

//État de la vague (Para/Ante/Bellum)
[System.Serializable]
public class State_Event : UnityEvent<GameState>
{

}

[System.Serializable]
public class Transform_Event: UnityEvent<Transform>
{

}
