using Charakted;
using System.Linq;
using UnityEngine;

namespace Enemies
{
    public class Chestnut : Enemy
    {
        private Vector3 _direction;
        private SpriteRenderer _sprite;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();

            _direction = transform.right;
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Shuriken _))
            {
                Destroy(gameObject);
            }

            if (collision.TryGetComponent(out Player player))
            {
                player.ReceivedDamage();
            }
        }

        private void Move()
        {
            Collider2D[] collidersFrontOf = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * _direction.x * 0.9f, 0.1f);
            Collider2D[] GroundColliders = Physics2D.OverlapCircleAll(transform.position + transform.up * -0.5f + transform.right * _direction.x * 0.9f, 0.1f);

            if (collidersFrontOf.Length > 0 && collidersFrontOf.All(x => !x.GetComponent<Player>() && !x.GetComponent<Coin>()) || GroundColliders.Length == 0 && GroundColliders.All(x => !x.GetComponent<Player>() && !x.GetComponent<Coin>()))
            {
                _direction *= -1.0f;
                _sprite.flipX = !_sprite.flipX;
            }

            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
        }
    }
}