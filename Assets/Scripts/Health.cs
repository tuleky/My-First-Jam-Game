using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] Transform _startingPoint;
    
    public void Die()
    {
        transform.position = _startingPoint.position;
    }
}