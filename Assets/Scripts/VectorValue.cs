using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject
{
    private Vector3 _initialValue;

    public Vector3 InitialValue { get => _initialValue; set => _initialValue = value; }
}
