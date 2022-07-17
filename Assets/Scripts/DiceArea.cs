using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceArea : MonoBehaviour
{
    [SerializeField] private GameObject _diceArea;
    
    [SerializeField] Rigidbody _dice;
    [SerializeField] Transform _diceRollStartingPoint;
    [SerializeField] private DiceFace[] _diceFaces;
    
    [SerializeField] private float _diceShowTimer;
    
    bool _isRolled;
    bool _isRandomForceGiven;
    bool _isDelayedInvokeCalled;
    
    public IEnumerator RollDice(Action<int> Callback)
    {
        CancelInvoke();HideDiceAndResetStates();
        _diceArea.SetActive(true);
        _isRolled = true;
        _dice.MovePosition(_diceRollStartingPoint.position);

        yield return new WaitForSeconds(_diceShowTimer);
        float highestY = -999f;
        DiceFace highestDiceFace = null;
        foreach (var diceFace in _diceFaces)
        {
            if (diceFace.transform.position.y > highestY)
            {
                highestY = diceFace.transform.position.y;
                highestDiceFace = diceFace;
            }
        }
        Callback.Invoke(highestDiceFace._faceNumber);
    }

    void FixedUpdate()
    {
        if (_isRolled)
        {
            if (!_isRandomForceGiven)
            {
                _dice.AddForce(Random.onUnitSphere * 0.7f, ForceMode.VelocityChange);
                _dice.AddTorque(Random.onUnitSphere * 20, ForceMode.VelocityChange);
                _isRandomForceGiven = true;
            }

            _dice.AddForce(Vector3.forward * 3f, ForceMode.Acceleration);

            if (!_isDelayedInvokeCalled)
            {
                Invoke(nameof(HideDiceAndResetStates), _diceShowTimer);
                _isDelayedInvokeCalled = true;
            }
        }
    }

    void HideDiceAndResetStates()
    {
        _isRolled = false;
        _isRandomForceGiven = false;
        _isDelayedInvokeCalled = false;
        _diceArea.SetActive(false);
        
    }
}