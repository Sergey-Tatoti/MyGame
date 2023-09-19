using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        other.gameObject.SetActive(false);
    }
}
