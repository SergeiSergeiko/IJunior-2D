using UnityEngine;

namespace Charakted
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundHitPlayer : MonoBehaviour
    {
        private AudioSource _playerSoundHit;

        private void Start()
        {
            _playerSoundHit = GetComponent<AudioSource>();
        }

        public void PlaySoundJump()
        {
            _playerSoundHit.Play();
        }
    }
}