using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrystal : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    private void Update()
    {
        if (_targetPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        }
    }

    public void SetTarget(Vector3 target)
    {
        _targetPosition = target;
    }
}
