using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] private Rigidbody _rigidbody;
    
    [SerializeField] float _moveSpeed;
    public bool IsTransferring { get; private set; }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        _characterController.SimpleMove(new Vector3(x * _moveSpeed, 0f, 0f));
    }

    public void MoveToTarget(Vector3 target)
    {
        _characterController.enabled = false;
        _rigidbody.MovePosition(target);
        _characterController.enabled = true;
    }

    public void JumpToTarget(Vector3 target)
    {
        IsTransferring = true;
        _characterController.enabled = false;
        transform.DOJump(target, 1f, 1, 1f).OnComplete(() =>
        {
            IsTransferring = false;
            _characterController.enabled = true;
        });
    }
}