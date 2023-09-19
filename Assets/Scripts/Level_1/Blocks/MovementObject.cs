using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    public void Move(Vector3 point, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime);
    }
}
