using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Enemys
{
    public class Acorn : MonoBehaviour
    {
        [SerializeField] private float _speed;

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

        private void LookFor()
        {
            Destroy(gameObject);
        }

        private void ChaseUser()
        {
            var _user = FindPlayerInScene();

            var direction = transform.position.x - _user.transform.position.x;

            transform.position = Vector3.MoveTowards(transform.position, _user.transform.position, _speed * Time.deltaTime);

            _sprite.flipX = direction < 0.0f;

            State = CharState.Step;
        }

        private GameObject FindPlayerInScene() => GameObject.Find("Player");
    }

    public enum CharState
    {
        Idle,
        Step,
        Explosion
    }
}
