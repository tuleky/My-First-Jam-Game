using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform[] _enemyPoints;

    int _rolledDiceValue;
    
    public void RollDice()
    {
        
    }

    void RollDiceForEnemyCreation()
    {
        _rolledDiceValue = Random.Range(1, 7);
        
        
    }
}