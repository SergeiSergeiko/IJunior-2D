using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
public class InfoWindow : MonoBehaviour
{    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void FadeInWindow()
    {
        _animator.SetTrigger("fadeIn");
    }

    public void FadeOutWindow()
    {
        _animator.SetTrigger("fadeOut");
    }
}
