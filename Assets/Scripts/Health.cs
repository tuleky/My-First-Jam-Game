using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    [SerializeField] private Mover _mover;
    
    public void Die()
    {
        _mover.MoveToTarget(_startingPoint.position);
    }
}