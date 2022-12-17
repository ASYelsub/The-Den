using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public LayerMask planeMask;

    Person _currentPerson;
    void Update()
    {




    }

    void PickUpPerson()
    {

    }

    void DropPerson()
    {
        _currentPerson?.PutDown();
    }
}
