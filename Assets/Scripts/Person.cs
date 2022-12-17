using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public float mouseFloatVal;
    bool isUp;

    Rigidbody _rigidBody;
    [SerializeField] LayerMask _planeMask;

    private void Start()
    {
        Services.PersonManager.AddPerson(this);
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (!isUp)
        {
            return;
        }
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, Mathf.Infinity, _planeMask))
        {
            Vector3 hitVec = hitInfo.point;
            transform.position = hitVec + new Vector3(0f, mouseFloatVal, 0f);
        }
    }

    void OnMouseDown()
    {
        PickUp();
    }


    void OnMouseUp()
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
