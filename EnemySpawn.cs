using System;
using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private GameObject[] _enemysInScene;

    private Vector3[] spawnPoints = new[] {
        new Vector3(14f, -2.5f, 0f),
        new Vector3(-11f, -1.5f, 0f),
        new Vector3(8f, -2.5f, 0f) };

    private void Start()
    {
        StartCoroutine(SpawnEnemys());
    }

    private void Update()
    {
        FindEnemys();
    }

    private void FindEnemys()
    {
        _enemysInScene = GameObject.FindGameObjectsWithTag("EnemyAcorn");
    }

    private IEnumerator SpawnEnemys()
    {
        var waitForSeconds = new WaitForSeconds(2);
        var waitUntil = new WaitUntil(() => _enemysInScene.Length < 3);

        for (int i = 0; true; i++)
        {
            Instantiate(_enemy, spawnPoints[i], Quaternion.identity);

            yield return waitForSeconds;
            yield return waitUntil;

            if (i >= 2)
            {
                i = 0;
            }
        }
    }
}
