using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private int _numberLevel;

    public void SwitchScene()
    {
        SceneManager.LoadScene(_numberLevel);
    }
}
