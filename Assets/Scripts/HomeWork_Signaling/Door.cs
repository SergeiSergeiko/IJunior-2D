using UnityEngine;
using Charakted;
using UnityEngine.Events;

namespace House
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private UnityEvent<bool> _reachedHouse = new();
        private Signaling _signaling;
        private bool _inHouse = false;
        
        private void Start()
        {
            _signaling = GetComponent<Signaling>();

            _reachedHouse.AddListener(_signaling.TriggerSignaling);
        }

        private void Update()
        {
            if (_inHouse && Input.GetKey(KeyCode.R))
            {
                _player.ChangeActiveIfHouse(_inHouse);

                _inHouse = false;
                _reachedHouse.Invoke(_inHouse);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (Input.GetKey(KeyCode.E) && collision.TryGetComponent(out Player player))
            {
                _inHouse = true;
                _reachedHouse.Invoke(_inHouse);
            }
        }
    }
}