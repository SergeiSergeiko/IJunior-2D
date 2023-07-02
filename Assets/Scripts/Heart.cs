using Charakted;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private SoundPickUpHearth _soundPickUpHearth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.Health++;
            Instantiate(_soundPickUpHearth);
            Destroy(gameObject);
        }
    }
}
