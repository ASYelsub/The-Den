using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlane : MonoBehaviour
{
    public Material activeMaterial;
    public Material inactiveMaterial;

    private void Start()
    {
        // material = GetComponent<MeshRenderer>().material;
    }

    public void HideFloorPlane()
    {
        // plane.gameObject.GetComponent<MeshRenderer>().material.color = showPlaneColor;
    }

    public void ShowFloorPlane()
    {
        // plane.gameObject.GetComponent<MeshRenderer>().material.color = showPlaneColor;
    }

    public void SetActiveVisual()
    {
        GetComponent<MeshRenderer>().material = activeMaterial;
    }

    public void SetInactiveVisual()
    {
        GetComponent<MeshRenderer>().material = inactiveMaterial;
    }
}
