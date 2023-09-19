using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Color))]

public class FadeBlock : MonoBehaviour
{
    private const float AlphaModifier = 0.8f;
    private const float BetaModifier = -0.4f;

    private Color _color;
    private Renderer _renderer;
    private float _currentAlpha;
    private int _maxAlpha = 1;
    private int _minAlpha = 0;
    private bool _isSimple;
    private bool _isFade;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _currentAlpha = _renderer.material.color.a;
    }

    private void FixedUpdate()
    {
        ChangeVisibility();
        ChangeCollider();
    }

    private void OnCollisionEnter(Collision other)
    {
        _isFade = true;
        _isSimple = false;
    }

    private void FadeVisual(float modifier)
    {
        _color = GetComponent<Renderer>().material.color;
        _currentAlpha -= Time.fixedDeltaTime * modifier;
        _color.a = _currentAlpha;
        _renderer.material.color = _color;
    }

    private void FadeCollider(bool value)
    {
        _isFade = false;
        _isSimple = value;
        GetComponent<BoxCollider>().isTrigger = value;
    }

    private void ChangeVisibility()
    {
        if (_isFade == true)
        {
            FadeVisual(AlphaModifier);
        }
        else if (_isSimple == true)
        {
            FadeVisual(BetaModifier);
        }
    }

    private void ChangeCollider()
    {
        if (_currentAlpha <= _minAlpha)
        {
            FadeCollider(true);
        }
        else if (_currentAlpha >= _maxAlpha)
        {
            FadeCollider(false);
        }
    }



}
