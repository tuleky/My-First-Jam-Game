using System;
using UnityEngine;

public class DiceTrigger : MonoBehaviour
{
    [SerializeField] private DiceArea _diceArea;
    [SerializeField] private EnemyAI _enemyAI;
    

    bool _isTriggered;
    
    void OnTriggerEnter(Collider other)
    {
        if (_isTriggered)
        {
            return;
        }
        
        if (other.TryGetComponent(out Mover mover))
        {
            StartCoroutine(_diceArea.RollDice(IncreaseEnemyPower));
            _isTriggered = true;
        }
    }

    void IncreaseEnemyPower(int x)
    {
        _enemyAI.SetDifficulty(x);
    }
}