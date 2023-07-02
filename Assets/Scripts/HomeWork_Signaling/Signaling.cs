using System.Collections;
using UnityEngine;

namespace House
{
    [RequireComponent(typeof(AudioSource))]
    public class Signaling : MonoBehaviour
    {
        [SerializeField] private float _recoveryRate = 2f;

        private Coroutine _volumeSignal;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = 0f;
        }

        public void TriggerSignaling(bool InHouse)
        {
            float maxVolume = 1f;
            float minVolume = 0f;

            if (InHouse)
            {
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }

                StopOldAndStartNewCoroutine(maxVolume);
            }
            else
            {
                StopOldAndStartNewCoroutine(minVolume);
            }
        }

        private IEnumerator FadeInVolumeSignaling(float currentVolume)
        {
            while (_audioSource.volume != currentVolume)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, currentVolume, _recoveryRate * Time.deltaTime);

                yield return null;
            }
            if (_audioSource.volume == 0f)
            {
                _audioSource.Stop();
            }
        }

        private void StopOldAndStartNewCoroutine(float TargetVolume)
        {
            if (_volumeSignal != null)
            {
                StopCoroutine(_volumeSignal);
            }
            _volumeSignal = StartCoroutine(FadeInVolumeSignaling(TargetVolume));
        }

        private void OnDisable()
        {
            if (_volumeSignal != null)
            {
                StopCoroutine(_volumeSignal);
            }
        }
    }
}
