using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPickUpCoin : MonoBehaviour
{
    private AudioSource _soundPickUpCoin;

    private void Awake()
    {
        _soundPickUpCoin = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlaySoundPickUpCoin();
    }

    private void Update()
    {
        if (!_soundPickUpCoin.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundPickUpCoin()
    {
        _soundPickUpCoin.Play();
    }
}