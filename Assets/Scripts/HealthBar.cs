using Charakted;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform[] _hearts = new Transform[5];
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();

        for (int i = 0; i < _hearts.Length; i++)
        {
            _hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (int i = _hearts.Length - 1; i >= 0; i--)
        {
            if (i > _player.Health)
            {
                _hearts[i].gameObject.SetActive(true);
            }
            else
            {
                _hearts[i].gameObject.SetActive(false);
            }
        }
    }
}
