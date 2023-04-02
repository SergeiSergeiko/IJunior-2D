using System;
using System.Collections;
using UnityEngine;

namespace House
{
    [RequireComponent(typeof(AudioSource))]

    public class Signaling : MonoBehaviour
    {
        [SerializeField] private float _recoveryRate = 2f;

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

                StartCoroutine(FadeInVolumeSignaling(maxVolume));
            }
            else
            {
                StartCoroutine(FadeInVolumeSignaling(minVolume));
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
    }
}
