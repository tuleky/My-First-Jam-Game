using System;
using UnityEngine;

public class DiceTrigger : MonoBehaviour
{
    [SerializeField] private DiceArea _diceArea;

    bool _isTriggered;
    
    void OnTriggerEnter(Collider other)
    {
        if (_isTriggered)
        {
            return;
        }
        
        if (other.TryGetComponent(out Mover mover))
        {
            _diceArea.RollDice();
            _isTriggered = true;
        }
    }
}