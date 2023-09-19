using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHeart : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _addHeartButton;
    
    public void AddHealth()
    {
        _player.AddHeart();

        if(_addHeartButton != null)
        _addHeartButton.interactable = false;
    }
}
