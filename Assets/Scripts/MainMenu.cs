using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _audioChoise;

    private void Start()
    {
        _audioChoise.volume = 1.0f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }

    public void PlaySoundChoise()
    {
        if (_audioChoise.isPlaying)
        {
            _audioChoise.Stop();
        }
        _audioChoise.Play();
    }
}