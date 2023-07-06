using UnityEngine;

namespace HomeWork
{
    public class Dragon : MonoBehaviour
    {
        [SerializeField] private float _damageAttack = 10f;
        [SerializeField] private Owl _targetForAttack;

        public void Attack()
        {
            _targetForAttack.Health -= _damageAttack;
        }
    }
}

