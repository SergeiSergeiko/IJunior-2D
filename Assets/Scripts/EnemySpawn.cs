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

        private SpawnPointEnemies[] _spawnPointsEnemies;

        private void Start()
        {
            _spawnPointsEnemies = GetComponentsInChildren<SpawnPointEnemies>();

            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            var count = 0;
            var waitForSeconds = new WaitForSeconds(2);

            while (true)
            {
                _spawnPointsEnemies[count].Spawn(_enemy, _player);

                yield return waitForSeconds;

                count++;
                if (count >= _spawnPointsEnemies.Length)
                {
                    count = 0;
                }
            }
        }
    }
}