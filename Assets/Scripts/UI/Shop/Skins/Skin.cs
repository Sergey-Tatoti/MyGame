using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skin : MonoBehaviour
{
  [SerializeField] private Color _emissionColor;
  [SerializeField] private Color _lightColor;
  [SerializeField] private Color _trailColor;
  [SerializeField] private Sprite _icon;
  [SerializeField] private int _price;
  [SerializeField] private int _number;
  [SerializeField] private bool _isBuyed = false;

  public Color EmissionColor => _emissionColor;
  public Color LightColor => _lightColor;
  public Color TrailColor => _trailColor;
  public Sprite Icon => _icon;
  public int Price => _price;
  public int Number => _number;
  public bool IsBuyed => _isBuyed;

  public void Buy()
  {
    _isBuyed = true;
  }
}
