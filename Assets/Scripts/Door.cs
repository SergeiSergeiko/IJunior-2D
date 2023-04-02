using System.Collections;
using UnityEngine;
using Charakted;
using UnityEngine.Events;

namespace House
{
    public class Door : MonoBehaviour
    {
        private UnityEvent<bool> _reached = new();
        private Signaling _signaling;
        private bool _inHouse = false;

        private void Start()
        {
            _signaling = GetComponent<Signaling>();

            _reached.AddListener(_signaling.TriggerSignaling);
        }

        private void Update()
        {
            if (_inHouse && Input.GetKey(KeyCode.R))
            {
                _inHouse = !_inHouse;
                _reached.Invoke(_inHouse);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (Input.GetKey(KeyCode.E) && collision.TryGetComponent(out Player player))
            {
                _inHouse = !_inHouse;
                _reached.Invoke(_inHouse);
            }
        }        
    }
}