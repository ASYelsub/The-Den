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

    public void EnablePeople()
    {
        foreach (Person p in allPeople)
        {
            p.gameObject.SetActive(true);
        }
    }

    public void DisablePeople()
    {
        foreach (Person p in allPeople)
        {
            p.gameObject.SetActive(false);
        }
    }
}
