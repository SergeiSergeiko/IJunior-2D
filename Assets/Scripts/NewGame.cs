using UnityEngine;

public class NewGame : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private VectorValue _vectroValue;
    [SerializeField] private HouseData _houseData;

    public void SetStartPositionPlayer()
    {
        _vectroValue.InitialValue = _startPosition.position;
        _houseData.InHouse = false;
        _houseData.LeftHouse = false;
    }
}