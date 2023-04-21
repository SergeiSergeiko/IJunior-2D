using Charakted;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private SpawnPointCoin[] _spawnPointsCoin;

    private void Start()
    {
         _spawnPointsCoin = GetComponentsInChildren<SpawnPointCoin>();

        foreach (var SpawnPoint in _spawnPointsCoin)
        {
            SpawnPoint.SpawnCoin(_coin);
        }
    }
}
