using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : Spot
{
   public FloorPlane upperFloor;
   public FloorPlane lowerFloor;

    protected override void Start()
    {
        
    }


   public override void ReceivePerson(Person p){
    Debug.Log("Stairs receieved " + p.myName);
    if(p.currentFloor.Equals(upperFloor)){
        p.SetCurrentFloor(lowerFloor);
        return;
    }
    if(p.currentFloor.Equals(lowerFloor)){
        p.SetCurrentFloor(upperFloor);
        return;
    }
   }
}
