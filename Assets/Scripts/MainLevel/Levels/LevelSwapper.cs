using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwapper : MonoBehaviour
{
    public void OnLevelUnlocked(Level level, Crystal smallCrystal, Crystal bigCrystal)
    {
        SwapCrystals(level, smallCrystal, bigCrystal);
    }

    private void SwapCrystals(Level level, Crystal smallCrystal, Crystal bigCrystal)
    {
        smallCrystal.ChangeTargetMovement(level.EndCrystalPosition);
        bigCrystal.ChangeTargetMovement(level.StartCrystalPosition);

        bigCrystal.gameObject.SetActive(true);
    }
}
