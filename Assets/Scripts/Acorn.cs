using UnityEngine;
using Enemies;
using Charakted;
using UnityEngine.Events;
using SpawnManager;

namespace Enemies
{
    public class Acorn : Enemy
    {
        private Player _player;
        private bool inCollision = false;

        private CharState State
        {
            get { return (CharState)_animator.GetInteger("State"); }
            set { _animator.SetInteger("State", (int)value); }
        }

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _sprite;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            if (!inCollision)
            {
                ChaseUser();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                inCollision = true;

                _rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
                _rigidbody.freezeRotation = true;

                State = CharState.Explosion;
            }
        }

        private void ChaseUser()
        {
            var direction = transform.position.x - _player.transform.position.x;

            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

            _sprite.flipX = direction < 0.0f;

            State = CharState.Step;
        }

        public void Init(Player player)
        {
            _player = player;
        }
    }
}

