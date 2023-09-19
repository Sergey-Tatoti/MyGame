using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class ButtonCube : MonoBehaviour
{
    [SerializeField] private AudioSource _pressSound;
    [SerializeField] private MovementButton _moveButton;
    [SerializeField] private float _pressingSpeed;
    [SerializeField] private float _maxPressing;

    private Vector3 _buttonStartPosition;
    private bool _canPressing;

    public UnityAction<bool> IsActivated;

    private void Awake()
    {
        _buttonStartPosition = transform.position;
    }

    private void Update()
    {
        CheckPressing();
    }

    private void OnTriggerEnter(Collider other)
    {
        _pressSound.Play();
        _canPressing = true;
        other.transform.parent = this.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        _pressSound.Play();
        _canPressing = false;
        other.transform.parent = null;
    }

    private void CheckPressing()
    {
        if (_canPressing == true)
        {
            ChangePosition(transform.position.y, _maxPressing, -_pressingSpeed);
        }
        else
        {
            ChangePosition(_buttonStartPosition.y, transform.position.y, _pressingSpeed);
        }
    }

    private void ChangePosition(float startPositionY, float finalPositionY, float pressingSpeed)
    {
        if (startPositionY >= finalPositionY)
        {
            _moveButton.Move(pressingSpeed);
            IsActivated?.Invoke(_canPressing);
        }
    }
}
