using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _deadlyHight;
    
    private Vector3 _startPosition;
    private Rigidbody _rigidbody;
    private float _startMassCube;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _startPosition = transform.position;
        _startMassCube = _rigidbody.mass;
    }

    private void Update() 
    {
        ReturnBack();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<TeleportBall>(out TeleportBall teleportBall) ||
        other.TryGetComponent<ButtonCube>(out ButtonCube button))
        {
            _rigidbody.mass = 1f;
        }
    }

    private void ReturnBack()
    {
        if (transform.position.y < _deadlyHight)
        {
            transform.position = _startPosition;
            _rigidbody.mass = _startMassCube;
        }
    }
}
