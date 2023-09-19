using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private MoveCrystal _moveCrystal;

    public void ChangeTargetMovement(Vector3 target)
    {
        _moveCrystal.SetTarget(target);
    }
}
