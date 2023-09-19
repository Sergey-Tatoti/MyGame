using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _maxRotationX;
    [SerializeField] private float _minRotationX;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private bool _canRotate = false;

    private void Start()
    {
        _maxRotation = Quaternion.Euler(new Vector3(_maxRotationX, 0f, 0f));
        _minRotation = Quaternion.Euler(new Vector3(_minRotationX, 0f, 0f));
    }

    private void Update()
    {
        if (_canRotate == true)
            Rotate(_minRotation);
        else
            Rotate(_maxRotation);
    }

    private void Rotate(Quaternion target)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * _speedRotation);
    }

    public void ActivateRotation(bool value)
    {
        _canRotate = value;
    }
}
