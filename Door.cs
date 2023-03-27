using System.Collections;
using UnityEngine;
using Charakted;

public class Door : MonoBehaviour
{
    [SerializeField] private float _recoveryRate;

    private AudioSource _audioSource;
    private bool _inHouse = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_inHouse && Input.GetKeyDown("r"))
        {
            _inHouse = !_inHouse;

            TriggerSignaling();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey("e") && collision.TryGetComponent(out Player player))
        {
            _inHouse = !_inHouse;

            TriggerSignaling();
        }
    }

    private void TriggerSignaling()
    {
        float maxVolume = 1f;
        float minVolume = 0f;

        if (_inHouse)
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
        if (!_inHouse && _audioSource.volume == 0f)
        {
            _audioSource.Stop();
        }
    }
}
