using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 directionMove = new Vector3(direction.x, 0, direction.y);
        Transform move = _camera.transform;

        if (directionMove.x > 0)
            _rigidbody.AddForce(move.right * _speed * Time.deltaTime);
        else if (directionMove.x < 0)
            _rigidbody.AddForce(move.right * -_speed * Time.deltaTime);

        if (directionMove.z > 0)
            _rigidbody.AddForce(move.forward * _speed * Time.deltaTime);
        else if (directionMove.z < 0)
            _rigidbody.AddForce(move.forward * -_speed * Time.deltaTime);
    }
}
