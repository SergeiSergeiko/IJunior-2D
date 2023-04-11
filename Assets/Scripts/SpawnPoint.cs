using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Enemies;
using Charakted;

namespace SpawnManager 
{
    public class SpawnPoint : MonoBehaviour
    {        
        private Enemy _enemy;

        public void Spawn(Enemy enemy, Player player)
        {
            if (_enemy == null)
            {
                _enemy = Instantiate(enemy, transform.position, Quaternion.identity);

                if (_enemy is Acorn acorn)
                {
                    acorn = (Acorn)_enemy;
                    acorn.Init(player);
                }
                _enemy.Died += OnDied;
            }            
        }

        private void OnDied()
        {
            _enemy.Died -= OnDied;
            _enemy = null;
        }
    }
}

