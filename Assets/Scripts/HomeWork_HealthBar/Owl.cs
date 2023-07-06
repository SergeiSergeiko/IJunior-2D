using UnityEngine;
using UnityEngine.Events;

namespace HomeWork
{
    public class Owl : MonoBehaviour
    {
        private const float MaxHealth = 100f;
        private const float MinHealth = 0f;

        [SerializeField] private HealthBar _healthBar;

        private UnityEvent _reportChangeHealthEvent = new();
        private float _health;

        public float Health
        {
            get { return _health; }

            set
            {
                _health = Mathf.Clamp(value, MinHealth, MaxHealth);
                _reportChangeHealthEvent.Invoke();
            }
        }

        private void Start()
        {
            _reportChangeHealthEvent.AddListener(_healthBar.HealthUpdate);
            Health = MaxHealth;
        }
    }
}

