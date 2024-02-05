using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool Placeable = true;
    public bool IsPlaceable { get { return Placeable; }} //Property

    [SerializeField] TowerStats ballistaTower;

 
    public void OnMouseDown()
    {
        if (Placeable == true)
        {
            bool isPlaced = ballistaTower.CreateTower(ballistaTower, transform.position);
            Placeable = !isPlaced;
        }
        
    }
}
