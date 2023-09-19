using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedData : MonoBehaviour
{
    private const string Crystals = "Crystals";
    private const string Skin = "Skin";
    [SerializeField] private Player _player;

    public void SaveValues()
    {
        //int totalCrystals = PlayerPrefs.GetInt(Crystals);

        PlayerPrefs.SetInt(Crystals, _player.CountCrystals);
    }
}
