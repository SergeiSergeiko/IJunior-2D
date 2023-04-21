using Enemies;
using UnityEngine;

namespace Charakted
{
    public class Shuriken : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.0f;

        private Vector3 _direction;
        public Vector3 Direction { set { _direction = value; } }

        private void Start()
        {
            Destroy(gameObject, 1.0f);
        }
        
        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy _))
            {
                Destroy(gameObject);
            }
        }
    }

    public enum CharStateShuriken
    {
        FlyLeft,
        FlyRight
    }
}