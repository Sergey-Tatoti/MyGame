using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Light))]

public class PlayerLook : MonoBehaviour
{
    private const string EmissionColor = "_EmissionColor";
    private const string SkinSave = "Skin";

    [SerializeField] private ParticleTrail _particleTrail;
    [SerializeField] private ParticleSystem _effectRebirth;
    [SerializeField] private List<Skin> _skins;

    private Renderer _renderer;
    private Light _light;
    private Skin _currentSkin;

    public Skin CurrentSkin => _currentSkin;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _light = GetComponent<Light>();

        _currentSkin = _skins[PlayerPrefs.GetInt(SkinSave)];
        ApplyColor(_currentSkin);
    }

    public void ChangeSkin(Skin skin)
    {
        _currentSkin = skin;

        ApplyColor(skin);

        PlayerPrefs.SetInt("Skin", _currentSkin.Number);
    }

    public void ShowRebirth(Vector3 savePoint)
    {
      int timeHidingEffect = 1;
      
      _effectRebirth.transform.position = savePoint;
      _effectRebirth.gameObject.SetActive(true);

      Invoke("HideEffect", timeHidingEffect);
    }

    private void HideEffect()
    {
        _effectRebirth.gameObject.SetActive(false);
    }

    private void ApplyColor(Skin skin)
    {
        _light.color = skin.LightColor;
        
        _renderer.material.SetColor(EmissionColor, skin.EmissionColor);
        _particleTrail.ChangeStartColor(skin.TrailColor);
    }
}
