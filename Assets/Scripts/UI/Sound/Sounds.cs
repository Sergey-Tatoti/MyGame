using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sounds : MonoBehaviour
{
    [SerializeField] public AudioSource[] _sounds;
    [SerializeField] public GameObject _soundFlag;

    public Sounds(AudioSource[] sounds, GameObject soundFlag)
    {
        _sounds = sounds;
        _soundFlag = soundFlag;
    }

    public void ChangeSounds()
    {
        if (GetSoundOn() == true)
        {
            SwitchSounds(!GetSoundOn());
        }
        else
            SwitchSounds(!GetSoundOn());
    }

    private bool GetSoundOn()
    {
        bool isTurn = false;

        for (int i = 0; i < _sounds.Length; i++)
        {
            if (_sounds[i].enabled == true)
                isTurn = true;
        }

        return isTurn;
    }

    private void SwitchSounds(bool isTurn)
    {
        for (int i = 0; i < _sounds.Length; i++)
        {
            _sounds[i].enabled = isTurn;
        }

        _soundFlag.SetActive(isTurn);
    }
}
