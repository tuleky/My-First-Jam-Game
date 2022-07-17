using System;
using UnityEngine;

public class DiceTrigger : MonoBehaviour
{
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
            StartCoroutine(DiceArea.Instance.RollDice(IncreaseEnemyPower));
            _isTriggered = true;
        }
    }

    void IncreaseEnemyPower(int x)
    {
        _enemyAI.SetDifficulty(x);
    }
}