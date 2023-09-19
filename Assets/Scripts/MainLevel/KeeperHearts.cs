using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperHearts : MonoBehaviour
{
    [SerializeField] private Player _player;

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
        if (heart < _player.MaxCountHealth)
            _player.AddHeart();
    }
}
