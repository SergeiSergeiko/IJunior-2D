using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Charakted
{
    public class Player : MonoBehaviour
    {
        public void ChangeActivePlayer()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
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
