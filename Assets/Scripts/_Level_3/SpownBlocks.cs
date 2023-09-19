using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownBlocks : PoolObjects
{
    [SerializeField] private GameObject[] _blocks;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_blocks[0]);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsSpawn)
        {
            if (TryGetObject(out GameObject block))
            {
                _elapsedTime = 0;

                int SpawnPointNumber = Random.Range(0, _spawnPoints.Length);
                int SpawnBlockNumber = Random.Range(0, _blocks.Length);

                SetBlock(block, _spawnPoints[SpawnPointNumber].position);
            }
        }
    }

    private void SetBlock(GameObject block, Vector3 spawnPoint)
    {
        block.SetActive(true);
        block.transform.position = spawnPoint;
    }

}
