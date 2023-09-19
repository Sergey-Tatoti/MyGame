using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class TeleportBall : MonoBehaviour
{
   [SerializeField] private AudioSource _teleportSound;
   [SerializeField] private float _positionX;
   [SerializeField] private float _positionY;
   [SerializeField] private float _positionZ;

   private void OnTriggerEnter(Collider other)
   {
      _teleportSound.Play();
      other.transform.position = new Vector3(_positionX, _positionY, _positionZ);
   }
}
