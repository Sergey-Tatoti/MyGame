using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButton : MonoBehaviour
{
    public void Move(float _speed)
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
}
