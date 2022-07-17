using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    Queue<BaseStatModifier> _statModifiers;
    WaitForSeconds _waitForSeconds;
    
    int _currentAttackDamage;

    void Awake()
    {
        _waitForSeconds = new WaitForSeconds(0.5f);
    }

    public void SetCurrentAttackDamage(int x)
    {
        _currentAttackDamage = x;
    }
    
    IEnumerator PlayApplyStatModifiersSequence()
    {
        while (_statModifiers.Count > 0)
        {
            _currentAttackDamage = _statModifiers.Dequeue().ApplyEffect(_currentAttackDamage);
            yield return _waitForSeconds;
        }
    }
}