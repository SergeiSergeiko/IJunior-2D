using UnityEngine;
using Charakted;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.Assertions.Must;
using UnityEditor.SearchService;

namespace House
{
    [RequireComponent(typeof(Signaling))]
    public class Door : MonoBehaviour
    {
        private UnityEvent<bool> _reachedHouse = new();
        private Signaling _signaling;
        private InfoWindow _infoWindow;

        private void Start()
        {
            _infoWindow = GetComponentInChildren<InfoWindow>();
            _signaling = GetComponent<Signaling>();

            _reachedHouse.AddListener(_signaling.TriggerSignaling);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (Input.GetKey(KeyCode.E) && collision.TryGetComponent(out Player _))
            {
                _reachedHouse.Invoke(true);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player _))
            {
                _infoWindow.FadeOutWindow();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player _))
            {
                _infoWindow.FadeInWindow();
                _reachedHouse.Invoke(false);
            }
        }
    }
}