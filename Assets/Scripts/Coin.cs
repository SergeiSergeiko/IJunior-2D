using Charakted;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private SoundPickUpCoin _soundPickUpCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.CountCoin++;
            Instantiate(_soundPickUpCoin);
            Destroy(gameObject);
        }
    }
}