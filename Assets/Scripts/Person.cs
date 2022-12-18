using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public float mouseFloatVal;
    bool _isUp;
    bool _isGrounded;

    Rigidbody _rigidBody;
    [SerializeField] LayerMask _planeMask;
    PersonState _myPersonState = PersonState.defaultFloor;

    private void Start()
    {
        Services.PersonManager.AddPerson(this);
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_isUp)
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
        _myPersonState = PersonState.beingHeld;
        _isGrounded = false;
        _isUp = true;
        _rigidBody.useGravity = false;
        Services.PersonManager.personBeingHeld = true;
    }

    public void PutDown()
    {
        _isUp = false;
        _rigidBody.useGravity = true;
        Services.PersonManager.personBeingHeld = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out FloorPlane floorPlane))
        {
            _isGrounded = true;
            _myPersonState = PersonState.defaultFloor;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Person otherPerson))
        {
            _myPersonState = PersonState.interactingOtherPerson;
            return;
        }
        // if (other.gameObject.TryGetComponent())
    }



}

public enum PersonState { defaultFloor, beingHeld, interactingOtherPerson, interactingWithObject }
