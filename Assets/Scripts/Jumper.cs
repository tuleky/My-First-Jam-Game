using System;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] Transform[] _jumpPoints;
    [SerializeField] private FloorManager _floorManager;
    [SerializeField] private int _rotateDir;
    
    Mover _mover;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Mover mover))
        {
            if (mover.IsTransferring)
            {
                return;
            }
            _mover = mover;
            StartCoroutine(DiceArea.Instance.RollDice(OnDiceRolled));
        }
    }

    void OnDiceRolled(int diceValue)
    {
        if (diceValue == 6)
        {
            diceValue -= 1;
        }
        _floorManager.RotateFloor(_rotateDir, diceValue - 1);
        _mover.JumpToTarget(_jumpPoints[diceValue - 1].position);
    }
}