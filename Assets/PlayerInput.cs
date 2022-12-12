using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    Person _currentPerson;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PickUpPerson();
            return;
        } 
        if (Input.GetMouseButtonUp(0))
        {
            DropPerson();
            return;
        }
       
    }

    void PickUpPerson()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
        {
            if (hitInfo.transform.gameObject.CompareTag("Person"))
            {
                _currentPerson = hitInfo.transform.GetComponent<Person>();
                _currentPerson.PickUp();
            }
        }
    }

    void DropPerson()
    {
        _currentPerson?.PutDown();
    }
}
