using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _points;

    private void OnEnable()
    {
        _player.CrystalsChanged += OnCrystalChanged;
    }

    private void OnDisable()
    {
        _player.CrystalsChanged -= OnCrystalChanged;
    }

    private void OnCrystalChanged(int countPoint)
    {
        _points.text = countPoint.ToString();
    }
}
