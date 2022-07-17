using System;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private DiceArea _diceArea;
    [SerializeField] private Transform[] _jumpPoints;

    Mover _mover;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Mover mover))
        {
            _mover = mover;
            StartCoroutine(_diceArea.RollDice(OnDiceRolled));
        }
    }

    void OnDiceRolled(int diceValue)
    {
        _mover.JumpToTarget(_jumpPoints[diceValue].position);
    }
}