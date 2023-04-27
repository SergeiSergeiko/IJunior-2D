using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _speed;

        public event UnityAction Died;

        private void LookFor()
        {
            Died.Invoke();
            Destroy(gameObject);
        }
    }

    public enum CharState
    {
        Idle,
        Step,
        Explosion
    }
}

