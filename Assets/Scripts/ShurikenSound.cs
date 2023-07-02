using UnityEngine;

namespace Charakted
{
    [RequireComponent(typeof(AudioSource))]
    public class ShurikenSound : MonoBehaviour
    {
        private AudioSource _soundShot;

        private void Start()
        {
            _soundShot = GetComponent<AudioSource>();

            PlaySoundShot();
        }

        private void PlaySoundShot()
        {
            _soundShot.Play();
        }
    }
}