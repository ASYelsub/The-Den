using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Services : MonoBehaviour
{
    private static GameManager _gameManager;
    public static GameManager GameManager
    {
        get
        {
            Debug.Assert(_gameManager != null);
            return _gameManager;
        }
        set => _gameManager = value;
    }

    private static PlaneManager _planeManager;
    public static PlaneManager PlaneManager
    {
        get
        {
            Debug.Assert(_planeManager != null);
            return _planeManager;
        }
        set => _planeManager = value;
    }

    public static void InitServices()
    {
        PlaneManager.Init();
        GameManager.Init();
    }

}
