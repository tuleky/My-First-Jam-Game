using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] private Floor[] _floors;
    int _currentFloorIndex;

    public void RotateFloor(int rotateDir, int floorIndex)
    {
        _currentFloorIndex += floorIndex;
        _floors[_currentFloorIndex].RotateFloor(rotateDir);
    }
}