using System;
using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] private Rigidbody _rigidbody;
    
    [SerializeField] float _moveSpeed;
    
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
        _characterController.enabled = false;
        _rigidbody.DOJump(target, 1f, 1, 0.5f);
        _characterController.enabled = true;
    }
}