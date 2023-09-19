using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private AudioSource[] _sounds;
    [SerializeField] private Player _player;
    [SerializeField] private GameOverMenu _gameOverMenu;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int heart)
    {
        if (heart > 0)
        {
            OpenGameOverMenu(1, false);
            SwitchSounds(0.2f);
        }
        else
        {
            OpenGameOverMenu(0, true);
            SwitchSounds(0);
        }

    }

    private void OpenGameOverMenu(int timeScale, bool isShow)
    {
        Time.timeScale = timeScale;
        _gameOverMenu.gameObject.SetActive(isShow);
    }

    private void SwitchSounds(float volume)
    {
        for (int i = 0; i < _sounds.Length; i++)
        {
            _sounds[i].GetComponent<AudioSource>().volume = volume;
        }
    }
}