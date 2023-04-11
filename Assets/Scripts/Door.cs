using System.Collections;
using UnityEngine;
using Charakted;
using UnityEngine.Events;
using System;

namespace House
{
    public class Door : MonoBehaviour
    {
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
                SetActivePlayer();

                _inHouse = false;
                _reachedHouse.Invoke(_inHouse);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (Input.GetKey(KeyCode.E) && collision.TryGetComponent(out Player player))
            {
                _inHouse = true;
                player.ChangeActivePlayer();
                _reachedHouse.Invoke(_inHouse);
            }
        }

        private void SetActivePlayer()
        {
            var player = GameObject.Find("Charakted");
            player.transform.Find("Player").gameObject.SetActive(true);
        }
    }
}