using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Level", menuName = "Level", order = 51)]

public class Level : ScriptableObject
{
  [SerializeField] private Crystal _bigCrystal;
  [SerializeField] private Crystal _smallCrystal;
  [SerializeField] private Vector3 _endCrystalPosition;
  [SerializeField] private Vector3 _startCrystalPosition;
  [SerializeField] private int _keyRequirements;
  [SerializeField] private int _numberScene;
  [SerializeField] private bool _isUnlock = false;

  public Crystal BigCrystal => _bigCrystal;
  public Crystal SmallCrystal => _smallCrystal;
  public Vector3 EndCrystalPosition => _endCrystalPosition;
  public Vector3 StartCrystalPosition => _startCrystalPosition;
  public int KeyRequirements => _keyRequirements;
  public int NumberScene => _numberScene;

  public void UnlockLevel()
  {
    _isUnlock = true;
  }
}
