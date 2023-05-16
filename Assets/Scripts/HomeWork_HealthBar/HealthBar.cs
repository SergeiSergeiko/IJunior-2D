using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace HomeWork
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void SetHealth(float Value)
        {
            _slider.DOValue(Value, _speed);
        }
    }
}

