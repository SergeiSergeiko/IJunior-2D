using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HouseData : ScriptableObject
{
    private bool _inHouse;
    private bool _leftHouse;

    public bool InHouse { get => _inHouse; set => _inHouse = value; }
    public bool LeftHouse { get => _leftHouse; set => _leftHouse = value; }
}
