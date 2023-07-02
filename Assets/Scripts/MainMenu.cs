using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NewGame))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _audioChoise;

    private NewGame _newGame;

    private void Start()
    {
        _audioChoise.volume = 1.0f;
        _newGame = GetComponent<NewGame>();
    }

    public void PlayGame()
    {
        _newGame.SetStartPositionPlayer();

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