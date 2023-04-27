using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChestnut : MonoBehaviour
{
    [SerializeField] private Chestnut _chestnut;

    private SpawnPointChestnut[] _spawnPointsChestnut;

    private void Awake()
    {
        _spawnPointsChestnut = new SpawnPointChestnut[transform.childCount];
        _spawnPointsChestnut = GetComponentsInChildren<SpawnPointChestnut>();
    }

    private void Start()
    {
        foreach (var SpawnPoint in _spawnPointsChestnut)
        {
            ÑreateChestnut(SpawnPoint.transform);
        }
    }

    public void ÑreateChestnut(Transform Transform)
    {
        Instantiate(_chestnut, Transform.position, Quaternion.identity);
    }
}
