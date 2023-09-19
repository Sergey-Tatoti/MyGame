using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PushingBall : MonoBehaviour
{
    [SerializeField] private AudioSource _pushSound;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _pushForce;

    private Rigidbody _rigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if (_rigidbody = other.GetComponent<Rigidbody>())
        {
            _pushSound.Play();
            _rigidbody.AddForce(_direction * _pushForce);
        }
    }
}
