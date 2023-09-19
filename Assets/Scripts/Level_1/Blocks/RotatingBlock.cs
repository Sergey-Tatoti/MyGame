using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBlock : MonoBehaviour
{
    [SerializeField] RotatingObject _rotatingBlock;

    private void OnCollisionEnter(Collision other)
    {
        Rotate(true);
    }

    private void OnCollisionExit(Collision other)
    {
        Rotate(false);
    }

    private void Rotate(bool canRotate)
    {
        _rotatingBlock.ActivateRotation(canRotate);
    }
}
