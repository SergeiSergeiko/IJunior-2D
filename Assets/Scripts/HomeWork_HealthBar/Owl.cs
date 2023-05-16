using UnityEngine;

namespace HomeWork
{
    public class Owl : MonoBehaviour
    {
        private const float _MaxHealth = 100f;
        private const float _MinHealth = 0f;
        
        [SerializeField] private HealthBar _healthBar;

        private float _health;
        private float _damage = 10;
        private float _heal = 10;

        public float Health
        {
            get { return _health; }

            set
            {
                _health = value;

                if (_health > _MaxHealth)
                {
                    _health = _MaxHealth;
                }
                if (_health <= _MinHealth)
                {
                    _health = _MinHealth;
                }                
                _healthBar.SetHealth(_health);
            }
        }

        private void Start()
        {
            Health = _MaxHealth;
        }

        public void GetHeal()
        {
            Health += _heal;
        }

        public void GetDamage()
        {
            Health -= _damage;
        }
    }
}

