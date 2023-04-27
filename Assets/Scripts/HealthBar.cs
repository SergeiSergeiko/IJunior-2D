using Charakted;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Transform[] _hearts;

    private void Awake()
    {
        _hearts = new Transform[transform.childCount];

        for (int i = 0; i < _hearts.Length; i++)
        {
            _hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < _player.Health)
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
