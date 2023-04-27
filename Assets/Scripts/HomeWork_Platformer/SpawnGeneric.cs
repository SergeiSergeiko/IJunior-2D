using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGeneric : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;

    private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = new SpawnPoint[transform.childCount];
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        foreach (var SpawnPoint in _spawnPoints)
        {
            CreateChestnut(SpawnPoint.transform);
        }
    }

    private void CreateChestnut(Transform Transform)
    {
        Instantiate(_spawnObject, Transform.position, Quaternion.identity);
    }
}
