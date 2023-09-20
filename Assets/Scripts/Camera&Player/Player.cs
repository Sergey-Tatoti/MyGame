using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private const string CrystalSave = "Crystals";
    
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerJumping _playerJumping;
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private int _maxCountHealth = 3;

    private PlayerInput _input;
    private Vector2 _direction;
    private Vector3 _savePoint;
    private int _countHealth;
    private int _countCrystals;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> CrystalsChanged;

    public int CountCrystals => _countCrystals;
    public int MaxCountHealth => _maxCountHealth;

    private void Start()
    {
        _input = new PlayerInput();
        _input.Enable();

        _input.Player.Jump.performed += ctx => _playerJumping.Jump();

        _countCrystals = PlayerPrefs.GetInt(CrystalSave);
        _countHealth = _maxCountHealth;

        HealthChanged?.Invoke(_maxCountHealth);
        CrystalsChanged?.Invoke(_countCrystals);
    }

    private void Update()
    {
        _direction = _input.Player.Move.ReadValue<Vector2>();

        _playerMovement.Move(_direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PointCrystal>(out PointCrystal pointCrystal))
        {
            _countCrystals++;
            CrystalsChanged?.Invoke(_countCrystals);
        }
    }

    public void ApplyDamage()
    {
        _countHealth--;

        HealthChanged?.Invoke(_countHealth);
        
        transform.position = _savePoint;
        _playerLook.ShowRebirth(_savePoint);
    }

    public void ChangeSavePoint(Vector3 savePoint)
    {
        _savePoint = savePoint;
    }

    public void BuySkin(Skin _skin)
    {
        _countCrystals -= _skin.Price;
        PlayerPrefs.SetInt(CrystalSave, _countCrystals);
        CrystalsChanged?.Invoke(_countCrystals);
    }

    public void AddHeart()
    {
        _countHealth++;
        HealthChanged?.Invoke(_countHealth);
    }
}
