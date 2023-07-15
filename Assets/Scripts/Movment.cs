using UnityEngine;

[RequireComponent(typeof(TesterInput))]
public class Movment : MonoBehaviour
{    
    [SerializeField] private float _speedRotation;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float horizontal, float vertical)
    {
        _rigidbody.MovePosition(_rigidbody.position + _rigidbody.transform.forward * vertical + _rigidbody.transform.right * horizontal);
    }    

    public void Rotate(float xRotation)
    {
        transform.Rotate(new Vector3(0f, xRotation, 0f) * _speedRotation);
    }
}
