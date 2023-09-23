using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyHeight : MonoBehaviour
{
    [SerializeField] private PlayerJumping _playerJumping;
    [SerializeField] private Player _player;
    [SerializeField] private float PermittedHeight;

    private void Start()
    {
        Vector3 playerPosition = _player.transform.position;

        transform.position = new Vector3(playerPosition.x, playerPosition.y - PermittedHeight, playerPosition.z);
    }

    private void OnEnable() 
    {
        _playerJumping.ReturnedGround += OnChangeHeight;
    }

    private void OnDisable() 
    {
        _playerJumping.ReturnedGround -= OnChangeHeight;
    }

    private void Update() 
    {
        OnTrackPositionPlayer();
    }

    private void OnTrackPositionPlayer()
    {
            if(transform.position.y >= _player.transform.position.y)
            {
                _player.ApplyDamage();
            }
    }

    private void OnChangeHeight()
    {
      transform.position = new Vector3(0, _player.transform.position.y - PermittedHeight, 0);
    }
}
