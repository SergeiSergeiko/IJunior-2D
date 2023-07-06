using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace HomeWork
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private float _speed = .2f;
        [SerializeField] private Owl _owl;

        private Slider _slider;
        private Tween _tween;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void SetHealth(float Value)
        {
            _tween.Kill();
            _tween = _slider.DOValue(Value, _speed);
        }

        public void HealthUpdate()
        {
            SetHealth(_owl.Health);
        }
    }
}

