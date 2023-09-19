using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWall : MonoBehaviour
{
    [SerializeField] private RotatingObject _rotatingWall;
    [SerializeField] private ButtonCube _button;

    private void OnEnable() 
    {
        _button.IsActivated += OnIsActivated;
    }
    private void OnDisable() 
    {
        _button.IsActivated -= OnIsActivated;
    }

    private void OnIsActivated(bool value)
    {
        _rotatingWall.ActivateRotation(value);
    }
}
