using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
  [SerializeField] private MovementObject _moveTransport;
  [SerializeField] private GameObject[] _targets;
  [SerializeField] private float _speed;

  private Vector3 _currentTarget;
  private int _numberTarget = 0;

  private bool _canMove;

  private void Awake()
  {
    _currentTarget = _targets[_numberTarget].transform.position;
  }

  private void OnCollisionEnter(Collision other)
  {
    other.transform.parent = this.transform;
    _canMove = true;
  }

  private void OnCollisionExit(Collision other)
  {
    other.transform.parent = null;
  }

  private void Update()
  {
    MoveTowardsTarget();
  }

  private void MoveTowardsTarget()
  {
    if (_canMove == true)
    {
      _moveTransport.Move(_currentTarget, _speed);
    }

    if (transform.position.x == _currentTarget.x && _numberTarget < _targets.Length - 1)
    {
      _numberTarget++;
      _currentTarget = _targets[_numberTarget].transform.position;
    }
    
    if (transform.position.x == _currentTarget.x && _numberTarget == _targets.Length - 1)
    {
      _canMove = false;
    }
  }
}
