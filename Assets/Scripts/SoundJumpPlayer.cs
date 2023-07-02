using UnityEngine;

namespace Charakted
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundJumpPlayer : MonoBehaviour
    {
        private AudioSource _playerSoundJump;

        private void Start()
        {
            _playerSoundJump = GetComponent<AudioSource>();
        }

        public void PlaySoundJump()
        {            
            _playerSoundJump.Play();
        }
    }
}