using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class PointCrystal : MonoBehaviour
{
  [SerializeField] private ParticleSystem _deathEffect;
  [SerializeField] private AudioSource _deathSound;

  private Renderer _renderer;

  private void Awake() 
  {
    _renderer = GetComponent<Renderer>();
  }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Player>(out Player _player))
        {
          _deathSound.Play();
          _renderer.enabled = false;
          _deathEffect.Play();

          Invoke("DestroyCrystal", 1f);
        }
    }

    private void DestroyCrystal()
    {
      Destroy(gameObject);
    }
}
