using System.Collections;
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
        [SerializeField] private int _maxEnemiesInScene = 3;

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
            var waitUntil = new WaitUntil(() => _countEnemiesInScene < _maxEnemiesInScene);

            while (true)
            {
                var spawnedEnemy = Instantiate(_enemy, spawnPointsEnemies[count].position, Quaternion.identity);
                spawnedEnemy.Init(_player, this);
                AddEnemiesInScene();

                yield return waitForSeconds;
                yield return waitUntil;

                count++;

                if (count >= _maxEnemiesInScene)
                {
                    count = 0;
                }
            }
        }
    }
}
