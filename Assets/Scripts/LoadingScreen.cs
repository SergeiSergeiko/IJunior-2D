using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private Slider _slider;
    private Coroutine _loadScreenFadeOn;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
    }

    public void StartLoadScreen(AsyncOperation operation)
    {
        RestartCoruotine(operation);
    }

    private IEnumerator LoadingScreenOnFade(AsyncOperation operation)
    {
        while (!operation.isDone)
        {
            _slider.value = Mathf.Clamp01(operation.progress / .9f);

            yield return null;
        }
    }

    private void RestartCoruotine(AsyncOperation operation)
    {
        if (_loadScreenFadeOn != null)
        {
            StopCoroutine(_loadScreenFadeOn);
        }
        _loadScreenFadeOn = StartCoroutine(LoadingScreenOnFade(operation));
    }
}