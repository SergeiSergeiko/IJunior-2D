using UnityEngine;

namespace HomeWork
{
    public class Rune : MonoBehaviour
    {
        [SerializeField] private float _healPower = 10f;
        [SerializeField] private Owl _targetForTreat;

        public void Treat()
        {
            _targetForTreat.Health += _healPower;
        }
    }
}

