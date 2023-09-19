using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MenuWindow : MonoBehaviour
{
    [SerializeField] private AudioSource[] _sounds;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private ShopView _shopView;
    [SerializeField] private GameObject _closeImage;
    [SerializeField] private GameObject _openImage;

    public void OpenMenu()
    {
        if (_pauseMenu.gameObject.activeSelf == true)
        {
            ShowMenu(1, false, true);
            TryCloseShop();
            SwitchSounds(0.1f);
        }
        else
        {
            ShowMenu(0, true, false);
            SwitchSounds(0);
        }

    }

    private void ShowMenu(int timeScale, bool isShow, bool isHide)
    {
        Time.timeScale = timeScale;
        _pauseMenu.gameObject.SetActive(isShow);
        _openImage.SetActive(isHide);
        _closeImage.SetActive(isShow);
    }

    private void TryCloseShop()
    {
        if (_shopView.gameObject.activeSelf)
            _shopView.gameObject.SetActive(false);
    }

    private void SwitchSounds(float volume)
    {
        for (int i = 0; i < _sounds.Length; i++)
        {
            _sounds[i].GetComponent<AudioSource>().volume = volume;
        }
    }
}