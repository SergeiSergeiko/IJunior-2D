using Enemies;
using UnityEngine;

public class SpawnPointChestnut : MonoBehaviour
{
    public void SpawnChestnut(Chestnut chestnut)
    {
        Instantiate(chestnut, transform.position, Quaternion.identity);
    }
}