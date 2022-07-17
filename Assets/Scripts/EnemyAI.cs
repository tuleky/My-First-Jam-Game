    using DG.Tweening;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform[] _targetPaths;
    [SerializeField] private EnemyAI _hiddenEnemy;
    Vector3[] _targetPathPoints;
    [SerializeField] float _pathFollowSpeed;

    bool _isFacingRight;
    
    void StartFollowPath(int difficulty)
    {
        _targetPathPoints = new Vector3[_targetPaths.Length];
        for (var i = 0; i < _targetPaths.Length; i++)
        {
            _targetPathPoints[i] = _targetPaths[i].position;
        }

        transform.DOPath(_targetPathPoints, _pathFollowSpeed - (difficulty / 6f)).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.Die();
        }
    }

    public void SetDifficulty(int difficulty)
    {
        if (difficulty > 3)
        {
            _hiddenEnemy.gameObject.SetActive(true);
        }
        StartFollowPath(difficulty);
    }
}
