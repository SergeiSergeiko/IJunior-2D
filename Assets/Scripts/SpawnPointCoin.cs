using Enemies;
using UnityEngine;

public class SpawnPointCoin : MonoBehaviour
{
    public void SpawnCoin(Coin coin)
    {
        Instantiate(coin, transform.position, Quaternion.identity);
    }
}
