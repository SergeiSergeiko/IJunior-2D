using UnityEngine;
using House;
using UnityEngine.Events;
using Unity.VisualScripting;

namespace Charakted
{
    public class Player : MonoBehaviour
    { 
        public void ChangeActivePlayer() => gameObject.SetActive(!gameObject.activeSelf);
    }

    public enum CharState
    {
        Idle,
        Step,
        Jump,
        Hit,
        Run
    }
}
