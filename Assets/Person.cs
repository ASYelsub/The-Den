using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public float mouseFloatVal;
    bool isUp;
    public GameObject plane;
    Rigidbody _rigidBody;

    public LayerMask planeMask;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        plane = Services.PlaneManager.activePlane.gameObject;
        Debug.Log("WorldToScreenPoint value of plane from camera:" + Camera.main.WorldToScreenPoint(plane.transform.position));
    }

    private void FixedUpdate()
    {

        if (!isUp)
        {
            return;
        }
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, Mathf.Infinity, planeMask))
        {
            Vector3 hitVec = hitInfo.point;
            Debug.Log(hitInfo.transform.gameObject.name);
            Debug.Log(hitVec);
            transform.position = hitVec + new Vector3(0f, mouseFloatVal, 0f);
        }
    }

    void OnMouseDown()
    {
        PickUp();

    }


    private void OnMouseUp()
    {
        PutDown();
    }

    public void PickUp()
    {
        isUp = true;
        _rigidBody.useGravity = false;
    }

    public void PutDown()
    {
        isUp = false;
        _rigidBody.useGravity = true;
    }
}
