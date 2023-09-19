using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrail : MonoBehaviour
{
    private ParticleSystem.MainModule _particleTrail;

    private void Awake()
    {
        _particleTrail = GetComponent<ParticleSystem>().main;
    }

    public void ChangeStartColor(Color color)
    {
        _particleTrail.startColor = color;
    }
}
