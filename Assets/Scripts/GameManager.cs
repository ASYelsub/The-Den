using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Awake()
    {
        Services.GameManager = this;
    }

    public void Start()
    {
        Services.InitServices(); // note, this GameManager itself gets its Init() method called within InitServices()
    }

    public void Init()
    {

    }
}
