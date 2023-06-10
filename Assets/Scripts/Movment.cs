using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{    
    [SerializeField] private float _speedRotation;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float h, float v)
    {
        _rigidbody.MovePosition(_rigidbody.position + _rigidbody.transform.forward * v + _rigidbody.transform.right * h);
    }    

    public void Rotation(float X)
    {
        transform.Rotate(new Vector3(0f, X, 0f) * _speedRotation);
    }
}
