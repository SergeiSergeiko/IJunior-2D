using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Charakted
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _knockbackForce;
        [SerializeField] private int _health = 5;
        [SerializeField] private Text _scoreText;

        public int Health
        {
            get 
            {
                return _health;
            } 
            set
            {
                if (value < 5)
                {
                    _health = value;
                }
                //_healthBar.Refresh();
            }
        }
        public int CountCoin { get { return _countCoin; } set { _countCoin++; } }

        private HealthBar _healthBar;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private Color _color;
        private Coroutine _courtine;
        public int _countCoin;

        private void Awake()
        {
            _healthBar = FindObjectOfType<HealthBar>();
        }

        private void Start()
        {
            _countCoin = 0;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _color = _spriteRenderer.material.color;
        }

        private void Update()
        {
            _scoreText.text = _countCoin.ToString();
        }

        public void ReceivedDamage()
        {
            Health--;

            _rigidbody2D.velocity = Vector3.zero;
            _rigidbody2D.AddForce(transform.up * _knockbackForce, ForceMode2D.Impulse);

            if (_courtine != null)
            {
                StopCoroutine(_courtine);
            }
            _courtine = StartCoroutine(FadeInVisibilityPlayer());
        }

        private IEnumerator FadeInVisibilityPlayer()
        {
            int count = 0;
            int countExit = 3;
            var wait = new WaitForSeconds(0.3f);
            Color visibility = new Color(_color.r, _color.g, _color.b, 200.0f);

            while (count < countExit)
            {
                _spriteRenderer.material.color = visibility;
                yield return wait;
                _spriteRenderer.material.color = _color;
                count++;
            }
        }
    }

    public enum CharState
    {
        Idle,
        Step,
        Jump,
        Shoot,
        Run
    }
}
