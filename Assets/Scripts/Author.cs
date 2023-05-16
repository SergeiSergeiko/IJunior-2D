using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Author : MonoBehaviour
{
    [SerializeField] private float _speedСhanges = 0.2f;

    private TextMeshProUGUI _textMeshProUGUI;
    private Coroutine _ChangesAlphaChannel;
    private float _alphaMin = 0f;
    private float _alphaMax = 1f;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _textMeshProUGUI.alpha = 0f;
    }

    private void OnDisable()
    {
        StopsCoroutine();
    }

    private void SetAlphaChannel(float TargetValue)
    {
        StopsCoroutine();
        if (gameObject.activeInHierarchy)
        {
            _ChangesAlphaChannel = StartCoroutine(FadeInAlphaChannel(TargetValue));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TriggerAuthor _))
        {
            SetAlphaChannel(_alphaMax);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TriggerAuthor _))
        {
            SetAlphaChannel(_alphaMin);
        }
    }

    private IEnumerator FadeInAlphaChannel(float TargetValue)
    {
        while (_textMeshProUGUI.alpha != TargetValue)
        {
            _textMeshProUGUI.alpha = Mathf.MoveTowards(_textMeshProUGUI.alpha, TargetValue, _speedСhanges * Time.deltaTime);

            yield return null;
        }
    }

    private void StopsCoroutine()
    {
        if (_ChangesAlphaChannel != null)
        {
            StopCoroutine(_ChangesAlphaChannel);
        }
    }
}

