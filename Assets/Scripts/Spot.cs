using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<Summary>
//A "spot" as in a place with an object at it/place that 
//is an object that people can interact with that players can place
public class Spot : MonoBehaviour
{
    [SerializeField]FloorPlane _associatedPlane;

    protected virtual void Start()
    {
        transform.SetParent(_associatedPlane.transform);
    }

    public virtual void ReceivePerson(Person p){

    }
}
