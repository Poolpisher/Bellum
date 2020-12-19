using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class State_Event : UnityEvent<GameState>
{

}

[System.Serializable]
public class Transform_Event: UnityEvent<Transform>
{

}
