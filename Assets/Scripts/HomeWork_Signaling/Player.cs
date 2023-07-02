using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using House;

namespace Charakted
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Movement))]
    public class Player : MonoBehaviour
    {
        private const int _MaxHealth = 5;

        [SerializeField] private float _knockbackForce;
        [SerializeField] private int _health = 5;
        [SerializeField] private Text _scoreText;
        [SerializeField] private HealthBar _healthBar;

        private AudioManagerPlayer _audioManagerPlayer;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private bool _isReceivedDamage = false;
        private int _countCoin;
        private Tween _fadeSprite;

        public int CountCoin
        {
            get
            {
                return _countCoin;
            }
            set
            {
                _countCoin++;
                RefreshScoreText();
            }
        }

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value < _MaxHealth)
                {
                    _health = value;
                }
                _healthBar.Refresh();
            }
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _audioManagerPlayer = GetComponentInChildren<AudioManagerPlayer>();
        }

        private void Start()
        {
            _countCoin = 0;
        }

        public void ReceivedDamage()
        {
            if (_isReceivedDamage == false)
            {
                _isReceivedDamage = true;

                _audioManagerPlayer.Hit();

                Health--;

                ActivateAnimationReceivedDamage();

                _rigidbody2D.velocity = Vector3.zero;
                _rigidbody2D.AddForce(transform.up * _knockbackForce, ForceMode2D.Impulse);
            }
        }

        private void ActivateAnimationReceivedDamage()
        {
            float EndValue = 0;
            float Duration = 0.3f;
            int Loops = 5;

            _fadeSprite.Kill();
            _fadeSprite = _spriteRenderer.DOFade(EndValue, Duration)
                .From()
                .SetLoops(Loops, LoopType.Restart)
                .OnComplete(() => _isReceivedDamage = false);
        }

        private void RefreshScoreText()
        {
            _scoreText.text = _countCoin.ToString();
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
