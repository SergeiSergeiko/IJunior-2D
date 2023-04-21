using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChestnut : MonoBehaviour
{
    [SerializeField] private Chestnut _chestnut;

    private SpawnPointChestnut[] _spawnPointsChestnut;

    private void Start()
    {
        _spawnPointsChestnut = GetComponentsInChildren<SpawnPointChestnut>();

        foreach (var SpawnPoint in _spawnPointsChestnut)
        {
            SpawnPoint.SpawnChestnut(_chestnut);
        }
    }
}
