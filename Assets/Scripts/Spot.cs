using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<Summary>
//A "spot" as in a place with an object at it/place that 
//is an object that people can interact with that players can place
public class Spot : MonoBehaviour
{
    FloorPlane _associatedPlane;

    void Start()
    {
        transform.SetParent(_associatedPlane.transform);
    }
}
