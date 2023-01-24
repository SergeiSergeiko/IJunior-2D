using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _recoveryRate;

    private Player _player;
    private bool _inHouse = false;

    private void Update()
    {
        if (_inHouse && Input.GetKeyDown("r"))
        {
            HouseController();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey("e") && collision.TryGetComponent<Player>(out Player player))
        {
            _player = player;

            HouseController();
        }
    }

    private void HouseController()
    {
        _inHouse = !_inHouse;
        _player.gameObject.SetActive(!_player.gameObject.activeSelf);

        PlaySignaling();
    }

    private void PlaySignaling()
    {
        if (_inHouse)
        {
            _audioSource.Play();
            StartCoroutine(FadeInVolumeSignaling());
        }
        else
        {            
            StartCoroutine(FadeInVolumeSignaling());
        }
    }

    private IEnumerator FadeInVolumeSignaling()
    {
        float _minVolume = 0f;
        float _maxVolume = 1.0f;
        ///sd

        if (_inHouse)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _recoveryRate * Time.deltaTime);
            if (_audioSource.volume == 1.0f || _inHouse == false)
            {
                yield break;
            }
            Debug.Log("Volum + 1");
        }
        else
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _recoveryRate * Time.deltaTime);
            if (_audioSource.volume == 0f || _inHouse == true)
            {
                _audioSource.Stop();

                yield break;
            }
            Debug.Log("Volum - 2");
        }

        yield return null;
    }
}
