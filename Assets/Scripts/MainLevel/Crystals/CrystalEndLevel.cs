using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CrystalEndLevel : MonoBehaviour
{
    [SerializeField] private SavedData _savedData;
    [SerializeField] private SceneSwitcher _SceneSwitcher;

    private void OnTriggerEnter(Collider other)
    {
        if (_savedData != null)
            _savedData.SaveValues();

        _SceneSwitcher.SwitchScene();
    }
}
