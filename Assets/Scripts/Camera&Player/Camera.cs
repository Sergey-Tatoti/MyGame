using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private float _sensitivityMouse = 0.1f;
    [SerializeField] private int _limitRotationY = 60;
    [SerializeField] private int _zoomMax = 10;
    [SerializeField] private int _zoomMin = 5;
    [SerializeField] private float _sensitivityZoom = 0.25f;

    private Vector2 _zoom;
    private Vector2 _rotate;
    private CameraInput _input;

    private void Awake()
    {
        _input = new CameraInput();
        _input.Enable();
    }

    private void Update()
    {
        _rotate = _input.Camera.Look.ReadValue<Vector2>();
        _zoom = _input.Camera.Zoom.ReadValue<Vector2>();

        _cameraMovement.UseZoom(_zoom, _sensitivityZoom, _zoomMax, _zoomMin);
        _cameraMovement.UseRotationAround(_rotate, _sensitivityMouse, _limitRotationY);

        _cameraMovement.Move();
    }

    public void StopMoving(bool _dontMove)
    {
        _cameraMovement.enabled = _dontMove;
    }
}
