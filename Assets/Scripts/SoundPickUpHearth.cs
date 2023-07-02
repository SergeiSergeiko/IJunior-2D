using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPickUpHearth : MonoBehaviour
{
    private AudioSource _soundPickUpHearth;

    private void Awake()
    {
        _soundPickUpHearth = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlaySoundPickUpHearth();
    }

    private void Update()
    {
        if (!_soundPickUpHearth.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundPickUpHearth()
    {
        _soundPickUpHearth.Play();
    }
}