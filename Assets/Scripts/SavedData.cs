using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedData : MonoBehaviour
{
    private const string Crystals = "Crystals";

    [SerializeField] private Player _player;

    public void SaveValues()
    {
        PlayerPrefs.SetInt(Crystals, _player.CountCrystals);
    }
}
