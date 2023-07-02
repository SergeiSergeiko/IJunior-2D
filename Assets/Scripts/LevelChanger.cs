using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private int _levelToLoad;
    [SerializeField] private LoadingScreen _loadingScreen;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        _animator.SetTrigger("fade");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(_levelToLoad);
        LoadingScreenOnFade();
    }

    private void LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_levelToLoad);

        _loadingScreen.gameObject.SetActive(true);
        _loadingScreen.StartLoadScreen(operation);
    }
}

