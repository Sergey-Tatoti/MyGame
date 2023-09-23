using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] private PointCrystal[] _pointCrystals;
    [SerializeField] private Player _player;
    [SerializeField] private Button _mainSceneButton;
    [SerializeField] private ChangeScene _changeScene;
    [SerializeField] private TMP_Text _maxCountCrystals;
    [SerializeField] private TMP_Text _countCrystals;

    private void Start()
    {
        Time.timeScale = 0;
        _maxCountCrystals.text = _pointCrystals.Length.ToString();
        _countCrystals.text = _player.CountCrystals.ToString();
    }

    private void OnEnable()
    {
        _mainSceneButton.onClick.AddListener(_changeScene.ReturnMainScene);
    }

    private void OnDisable()
    {
        _mainSceneButton.onClick.RemoveListener(_changeScene.ReturnMainScene);
    }
}
