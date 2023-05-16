using System;
using UnityEngine;

public class ListAuthors : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 20f;
    [SerializeField] private Transform _transform;

    private void OnEnable()
    {
        transform.position = new Vector3(_transform.position.x, _transform.position.y, _transform.position.z);
    }

    private void Update()
    {
        PlayAuthors();
    }

    private void PlayAuthors()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position +
            transform.up, _movementSpeed * Time.deltaTime);
    }
}