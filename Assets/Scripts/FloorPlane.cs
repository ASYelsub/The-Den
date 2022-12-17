using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlane : MonoBehaviour
{
    public Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public void HideFloorPlane()
    {
       // plane.gameObject.GetComponent<MeshRenderer>().material.color = showPlaneColor;
    }

    public void ShowFloorPlane()
    {
       // plane.gameObject.GetComponent<MeshRenderer>().material.color = showPlaneColor;
    }
}
