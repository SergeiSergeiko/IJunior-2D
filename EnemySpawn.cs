using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Charakted;
using Enemies;

namespace SpawnManager
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private Acorn _enemy;
        [SerializeField] private Player _player;
        [SerializeField] private Transform[] spawnPointsEnemies;

        private int _countEnemiesInScene = 0;

        private void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        private void AddEnemiesInScene()
        {
            _countEnemiesInScene++;
        }

        public void RemoveEnemiesInScene()
        {
            _countEnemiesInScene--;
        }

        private IEnumerator SpawnEnemies()
        {
            var count = 0;
            var waitForSeconds = new WaitForSeconds(2);
            var waitUntil = new WaitUntil(() => _countEnemiesInScene < 3);

            while (true)
            {
                var spawnedEnemy = Instantiate(_enemy, spawnPointsEnemies[count].position, Quaternion.identity);
                spawnedEnemy.Init(_player, this);
                AddEnemiesInScene();

                yield return waitForSeconds;
                yield return waitUntil;

                count++;

                if (count > 2)
                {
                    count = 0;
                }
            }
        }
    }
}
