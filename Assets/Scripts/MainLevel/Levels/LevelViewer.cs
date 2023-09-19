using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelViewer : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;
    [SerializeField] private LevelCreator _levelCreator;
    [SerializeField] private LevelSwapper _levelSwapper;
    [SerializeField] private LevelUnlocker _levelUnlocker;

    private void OnEnable()
    {
        _levelCreator.LevelCreated += _levelUnlocker.OnLevelCreated;
        _levelUnlocker.LevelUnlocked += _levelSwapper.OnLevelUnlocked;
    }

    private void OnDisable()
    {
        _levelCreator.LevelCreated -= _levelUnlocker.OnLevelCreated;
        _levelUnlocker.LevelUnlocked -= _levelSwapper.OnLevelUnlocked;
    }

    private void Start()
    {
        for (int i = 0; i < _levels.Count; i++)
        {
            _levelCreator.CreateCrystal(_levels[i]);
        }
    }
}
