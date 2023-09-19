using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayingObject : MonoBehaviour
{
    [SerializeField] private ButtonCube _button;
    [SerializeField] private GameObject _object;

    private void OnEnable() 
    {
        _button.IsActivated +=  OnIsActivated;
    }

    private void OnDisable() 
    {
        _button.IsActivated -=  OnIsActivated;
    }

    private void OnIsActivated(bool value)
    {
        _object.gameObject.SetActive(value);
    }
}
