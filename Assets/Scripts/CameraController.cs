using Charakted;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private Transform _target;
    [SerializeField] private SpriteRenderer _sprite;

    private void Awake()
    {
        if (!_target)
        {
            _target = FindObjectOfType<Player>().transform;
        }
    }

    void Update()
    {
        Vector3 position = _target.position;
        position.z = -10.0f;

        transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);
    }
}
