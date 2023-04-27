using Charakted;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private SpawnPointCoin[] _spawnPointsCoin;

    private void Awake()
    {
        _spawnPointsCoin = new SpawnPointCoin[transform.childCount];
        _spawnPointsCoin = GetComponentsInChildren<SpawnPointCoin>();
    }

    private void Start()
    {
        foreach (var SpawnPoint in _spawnPointsCoin)
        {
            СreateCoin(SpawnPoint.transform);
        }
    }

    private void СreateCoin(Transform Transform)
    {
        Instantiate(_coin, Transform.position, Quaternion.identity);
    }
}
