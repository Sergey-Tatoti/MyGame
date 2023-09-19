using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelUnlocker : MonoBehaviour
{
  [SerializeField] private AudioSource _crystalSounds;

  public UnityAction<Level, Crystal, Crystal> LevelUnlocked;

  public void OnLevelCreated(Level level, Crystal smallCrystal, Crystal bigCrystal)
  {
    TryUnlockLevel(level, smallCrystal, bigCrystal);
  }

  private void TryUnlockLevel(Level level, Crystal smallCrystal, Crystal bigCrystal)
  {
    level.UnlockLevel();
    _crystalSounds.enabled = true;

    LevelUnlocked?.Invoke(level, smallCrystal, bigCrystal);
  }
}