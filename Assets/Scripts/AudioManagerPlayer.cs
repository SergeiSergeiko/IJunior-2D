using System;
using UnityEngine;

namespace Charakted
{
    public class AudioManagerPlayer : MonoBehaviour
    {
        private SoundJumpPlayer _jump;
        private SoundHitPlayer _hit;

        private void Awake()
        {
            _jump = GetComponentInChildren<SoundJumpPlayer>();
            _hit = GetComponentInChildren<SoundHitPlayer>();
        }

        public void Jump()
        {
            _jump.PlaySoundJump();
        }

        public void Hit()
        {
            _hit.PlaySoundJump();
        }
    }
}
