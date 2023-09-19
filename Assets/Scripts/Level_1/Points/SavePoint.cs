using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
          player.ChangeSavePoint(transform.position);
        }
    }
}
