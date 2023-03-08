using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float _recoveryRate;
    
    private AudioSource _audioSource;
    private Player _player;
    private bool _inHouse = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_inHouse && Input.GetKeyDown("r"))
        {
            HouseController();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey("e") && collision.TryGetComponent(out Player player))
        {
            _player = player;

            HouseController();
        }
    }

    private void HouseController()
    {
        _inHouse = !_inHouse;
        _player.gameObject.SetActive(!_player.gameObject.activeSelf);

        TriggerSignaling();
    }

    private void TriggerSignaling()
    {
        float maxVolume = 1f;
        float minVolume = 0f;

        if (_inHouse)
        {
            PlaySignaling(maxVolume);
        }
        else
        {
            PlaySignaling(minVolume);
        }
    }

    private void PlaySignaling(float currentVolume)
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        StartCoroutine(FadeInVolumeSignaling(currentVolume));
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