using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private float _xPosition;
    private float _yPosition;

    public void UseRotationAround(Vector2 rotate, float sensitivityMouse, int limitRotationY)
    {
        _xPosition = transform.localEulerAngles.y + rotate.x * sensitivityMouse;
        _yPosition += rotate.y * sensitivityMouse;
        _yPosition = Mathf.Clamp(_yPosition, -limitRotationY, limitRotationY);
        transform.localEulerAngles = new Vector3(-_yPosition, _xPosition, 0);
    }

    public void UseZoom(Vector2 zoom, float sensitivityZoom, int zoomMax, int zoomMin)
    {
        if (zoom.y > 0)
        {
            _offset.z += sensitivityZoom;
        }
        else if (zoom.y < 0)
        {
            _offset.z -= sensitivityZoom;
        }

        _offset.z = Mathf.Clamp(_offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
    }

    public void Move()
    {
        transform.position = transform.localRotation * _offset + _target.position;
    }
}