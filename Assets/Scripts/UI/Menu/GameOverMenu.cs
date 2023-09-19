using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainSceneButton;
    [SerializeField] private Button _addHeartButton;
    [SerializeField] private ChangeScene _changeScene;
    [SerializeField] private AddHeart _addHeart;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(_changeScene.ReloadScene);
        _mainSceneButton.onClick.AddListener(_changeScene.ReturnMainScene);
        _addHeartButton.onClick.AddListener(_addHeart.AddHealth);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(_changeScene.ReloadScene);
        _mainSceneButton.onClick.RemoveListener(_changeScene.ReturnMainScene);
        _addHeartButton.onClick.RemoveListener(_addHeart.AddHealth);
    }
}
