using Charakted;
using System.Linq;
using UnityEngine;

namespace Enemies
{
    public class Chestnut : Enemy
    {
        private const float _factorForOverlapCircleY = 0.5f;
        private const float _factorForOverlapCircleX = 0.9f;
        private const float _radiusForOverlapCircle = 0.1f;

        private Vector3 _direction;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

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

            Collider2D[] CollidersFrontOf = Physics2D.OverlapCircleAll(transform.position + transform.up * _factorForOverlapCircleY
                + transform.right * _direction.x * _factorForOverlapCircleX, _radiusForOverlapCircle);
            Collider2D[] GroundColliders = Physics2D.OverlapCircleAll(transform.position + transform.up * -_factorForOverlapCircleY
                + transform.right * _direction.x * _factorForOverlapCircleX, _radiusForOverlapCircle);

            if (CollidersFrontOf.Length > 0 && CollidersFrontOf.All(x => !x.GetComponent<Player>() && !x.GetComponent<Coin>()) 
               || GroundColliders.Length == 0 && GroundColliders.All(x => !x.GetComponent<Player>() && !x.GetComponent<Coin>()))
            {
                _direction *= -1.0f;
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
            }

            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
        }
    }
}