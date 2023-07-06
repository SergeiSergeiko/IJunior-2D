using UnityEngine;

namespace HomeWork
{
    public class Owl : MonoBehaviour
    {
        private const float MaxHealth = 100f;
        private const float MinHealth = 0f;

        private float _health;

        public float Health
        {
            get { return _health; }

            set
            {
                _health = Mathf.Clamp(value, MinHealth, MaxHealth);
            }
        }

        private void Start()
        {
            Health = MaxHealth;
        }
    }
}

