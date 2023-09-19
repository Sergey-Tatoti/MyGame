using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private MovementObject _moveBlock;
    [SerializeField] private float _speed;
    [SerializeField] private int _distanceX;
    [SerializeField] private int _distanceY;
    [SerializeField] private int _distanceZ;

    private Vector3 _firstPosition;
    private Vector3 _secondPosition;
    private Vector3 _temporaryPosition;

    private void Start()
    {
        _firstPosition = new Vector3(transform.position.x - _distanceX, transform.position.y - _distanceY, transform.position.z - _distanceZ);
        _secondPosition = new Vector3(transform.position.x + _distanceX, transform.position.y + _distanceY, transform.position.z + _distanceZ);

        _temporaryPosition = _firstPosition;
    }

    private void Update()
    {
        _moveBlock.Move(_temporaryPosition, _speed);

        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (transform.position == _firstPosition)
        {
            _temporaryPosition = _secondPosition;
        }
        else if (transform.position == _secondPosition)
        {
            _temporaryPosition = _firstPosition;
        }
    }
}

