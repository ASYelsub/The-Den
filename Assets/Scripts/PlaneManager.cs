using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneManager : MonoBehaviour
{
    public Color showPlaneColor;
    public Color hidePlaneColor;
    public FloorPlane activePlane;

    public List<FloorPlane> allPlanes = new List<FloorPlane>();

    public enum FloorPlaneNames { B1, F1, F2 };


    public List<Button> siftPlaneButtons = new List<Button>();

    int _activePlaneVal;
    bool _sifting = false;

    private void Awake()
    {
        Services.PlaneManager = this;
    }

    public void Init()
    {
        //Debug.Log("Init called from PlaneManager.");
        HideExtraPlanes();
        HideSiftButtons();
        ///Assigning active plane///
        for (int i = 0; i < allPlanes.Count; i++)
        {
            if (activePlane.Equals(allPlanes[i]))
            {
                _activePlaneVal = i;
                return;
            }
        }
    }

    private void Update()
    {

        if (Services.PersonManager.personBeingHeld)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Services.PersonManager.DisablePeople();
            ShowAllPlanes();
            SetAppearanceAllPlanes();
            ShowSiftButtons();
            _sifting = true;
            return;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Services.PersonManager.EnablePeople();
            HideExtraPlanes();
            HideSiftButtons();
            _sifting = false;
            return;
        }

        if (!_sifting)
        {
            return;
        }
        ///Another way to sift Up
        if (Input.GetKeyUp(KeyCode.R))
        {
            SiftUpActivePlane();
            return;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            SiftDownActivePlane();
            return;
        }
    }

    void ShowSiftButtons()
    {
        foreach (Button button in siftPlaneButtons)
        {
            button.gameObject.SetActive(true);
        }
    }

    void HideSiftButtons()
    {
        foreach (Button button in siftPlaneButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    void ShowAllPlanes()
    {
        foreach (FloorPlane plane in allPlanes)
        {
            plane.gameObject.SetActive(true);
        }
    }


    void SetAppearanceAllPlanes()
    {
        foreach (FloorPlane plane in allPlanes)
        {
            //This is the tester function for the set functionality
            // Color c = plane.gameObject.GetComponent<MeshRenderer>().material.GetColor("_Color");
            // if (activePlane.Equals(plane))
            // {
            //     plane.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(c.r, c.g, c.b, 1f));
            //     continue;
            // }
            // plane.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(c.r, c.g, c.b, .5f));

            if (activePlane.Equals(plane))
            {
                plane.SetActiveVisual();
                continue;
            }
            plane.SetInactiveVisual();
        }
    }

    void HideExtraPlanes()
    {
        //Debug.Log("HideExtraPlanes call");
        foreach (FloorPlane plane in allPlanes)
        {
            if (activePlane.Equals(plane))
            {
                continue;
            }
            plane.gameObject.SetActive(false);
            plane.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    /// <summary>
    /// Called externally by canvas button.
    /// </summary>
    public void SiftUpActivePlane()
    {
        if (_activePlaneVal >= allPlanes.Count - 1)
        {
            SiftBump();
            return;
        }
        activePlane.gameObject.GetComponent<Collider>().enabled = false;
        _activePlaneVal++;
        activePlane = allPlanes[_activePlaneVal];
        activePlane.gameObject.GetComponent<Collider>().enabled = true;
        foreach (FloorPlane plane in allPlanes)
        {
            plane.transform.position += new Vector3(1f, -1f, 1f);
        }
        SetAppearanceAllPlanes();

    }

    /// <summary>
    /// Called externally by canvas button.
    /// </summary>
    public void SiftDownActivePlane()
    {
        if (_activePlaneVal <= 0)
        {
            SiftBump();
            return;
        }
        activePlane.gameObject.GetComponent<Collider>().enabled = false;
        _activePlaneVal--;
        activePlane = allPlanes[_activePlaneVal];
        activePlane.gameObject.GetComponent<Collider>().enabled = true;
        foreach (FloorPlane plane in allPlanes)
        {
            plane.transform.position += new Vector3(-1f, 1f, -1f);
        }
        SetAppearanceAllPlanes();
    }


    /// <summary>
    /// Called when there are no planes to sift through.
    /// </summary>
    void SiftBump()
    {

    }
}
