using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterInput : MonoBehaviour
{
    [SerializeField] private Movment _movment;

    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");

        _movment.Rotate(mouseX);
    }

    private void FixedUpdate()
    {
        _movment.Move(_horizontal, _vertical);
    }
}
