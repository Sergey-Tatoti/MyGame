using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelCreator : MonoBehaviour
{
    private Crystal _bigCrystal;
    private Crystal _smallCrystal;
    
    public UnityAction<Level, Crystal, Crystal> LevelCreated;

    public void CreateCrystal(Level level)
    {
        _smallCrystal = Create(_smallCrystal, level.SmallCrystal, level.StartCrystalPosition);
        _bigCrystal = Create(_bigCrystal, level.BigCrystal, level.EndCrystalPosition);

        _bigCrystal.gameObject.SetActive(false);

        LevelCreated?.Invoke(level, _smallCrystal, _bigCrystal);
    }

    private Crystal Create(Crystal crystal, Crystal tamplateCrystal, Vector3 targetPosition)
    {
       crystal = Instantiate(tamplateCrystal, targetPosition, Quaternion.identity);
       crystal.gameObject.transform.SetParent(this.transform);

       return crystal;
    }
}
