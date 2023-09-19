using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainSceneButton;
    [SerializeField] private ChangeScene _changeScene;
    [SerializeField] private Button _musicButton;
    [SerializeField] private MusicSounds _musicSounds;
    [SerializeField] private Button _soundEffectButton;
    [SerializeField] private EffectSounds _effectSounds;
    [SerializeField] private Button _shopButton;
    [SerializeField] private ShopWindow _shopWindow;
    
    private void OnEnable()
    {
        _restartButton.onClick.AddListener(_changeScene.ReloadScene);
        _mainSceneButton.onClick.AddListener(_changeScene.ReturnMainScene);
        _musicButton.onClick.AddListener(_musicSounds.ChangeSounds);
        _soundEffectButton.onClick.AddListener(_effectSounds.ChangeSounds);
        _shopButton.onClick.AddListener(_shopWindow.ShowShop);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(_changeScene.ReloadScene);
        _mainSceneButton.onClick.RemoveListener(_changeScene.ReturnMainScene);
        _musicButton.onClick.RemoveListener(_musicSounds.ChangeSounds);
        _soundEffectButton.onClick.RemoveListener(_effectSounds.ChangeSounds);
        _shopButton.onClick.RemoveListener(_shopWindow.ShowShop);
    }
}
