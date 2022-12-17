using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonManager : MonoBehaviour
{
    [HideInInspector] public List<Person> allPeople = new List<Person>();

    public void Awake()
    {
        Services.PersonManager = this;
    }
    public void Init()
    {

    }

    public void AddPerson(Person p)
    {
        allPeople.Add(p);
    }
}