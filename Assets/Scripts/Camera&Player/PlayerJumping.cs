using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] private AudioSource _soundJump;
    [SerializeField] private int _jumpForce;

    private Rigidbody _rigidbody;

    public bool IsGround { get; private set; }
    public event UnityAction ReturnedGround;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _soundJump = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        IsGround = true;

        ReturnedGround?.Invoke();
    }

    public void Jump()
    {
        if (IsGround == true)
        {
            if(_soundJump == null) return;

            _soundJump.Play();
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            IsGround = false;
        }
    }
}
