using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heart;

    private List<Heart> _hearts = new List<Heart>();

    private void Awake()
    {
        OnHealthChanged(_player.MaxCountHealth);
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int countHealth)
    {
        if (_hearts.Count < countHealth)
        {
            int creatHealth = countHealth - _hearts.Count;

            for (int i = 0; i < creatHealth; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > countHealth)
        {
            int destroyHealth = _hearts.Count - countHealth;

            for (int i = 0; i < destroyHealth; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heart, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}
