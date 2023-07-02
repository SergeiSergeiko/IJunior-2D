using Charakted;
using Unity.VisualScripting;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ReceivedDamage();
        }
    }
}