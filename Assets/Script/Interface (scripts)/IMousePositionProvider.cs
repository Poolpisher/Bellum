using UnityEngine;

public interface IMousePositionProvider
{
    public Vector3 look{get;}
    public Vector3 worldMousePos{get;}
    //Position de la souris
    public Vector2 mousePos{get;}
    public float aimAngle{get;}


    public void CalculateMousePos(Vector2 rawPos);
}