using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBalls : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speedRotation;

    private void Update() 
    {
        transform.RotateAround(transform.position, _direction, _speedRotation * Time.deltaTime);
    }
}
