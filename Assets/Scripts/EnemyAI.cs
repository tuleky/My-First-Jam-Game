using DG.Tweening;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform[] _targetPaths;
    Vector3[] _targetPathPoints;
    [SerializeField] float _pathFollowSpeed;

    bool _isFacingRight;
    
    void Start()
    {
        _targetPathPoints = new Vector3[_targetPaths.Length];
        for (var i = 0; i < _targetPaths.Length; i++)
        {
            _targetPathPoints[i] = _targetPaths[i].position;
        }

        transform.DOPath(_targetPathPoints, _pathFollowSpeed).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.Die();
        }
    }
}
