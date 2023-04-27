using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Charakted
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _knockbackForce;
        [SerializeField] private int _health = 5;
        [SerializeField] private Text _scoreText;
        [SerializeField] private HealthBar _healthBar;

        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private bool _isReceivedDamage = false;
        private int _countCoin;

        public int CountCoin { get { return _countCoin; } set { _countCoin++; } }
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
                _healthBar.Refresh();
            }
        }

        private void Start()
        {
            _countCoin = 0;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();            
        }

        private void Update()
        {
            _scoreText.text = _countCoin.ToString();
        }

        public void ReceivedDamage()
        {
            if (!_isReceivedDamage)
            {
                Health--;

                ActivateAnimationReceivedDamage();

                _rigidbody2D.velocity = Vector3.zero;
                _rigidbody2D.AddForce(transform.up * _knockbackForce, ForceMode2D.Impulse);
            }
        }

        private void ActivateAnimationReceivedDamage()
        {
            _spriteRenderer.DOFade(0, 0.3f)
                .From()
                .SetLoops(5, LoopType.Restart)
                .OnComplete(() => _isReceivedDamage = false);
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
