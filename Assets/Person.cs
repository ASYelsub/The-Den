using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public float mouseFloatVal;
    bool isUp;
    public GameObject plane;
    private Vector3 mOffset;
    private float mZCoord;
    Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isUp)
        {
            transform.localPosition = GetMouseAsWorldPoint() + mOffset;
        }
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.localPosition - GetMouseAsWorldPoint() + new Vector3(0f,mouseFloatVal,0f);
    }

   
    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        mousePoint = Camera.main.ScreenToWorldPoint(mousePoint);
        mousePoint.y = plane.GetComponent<Transform>().position.y;
        return mousePoint;
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
