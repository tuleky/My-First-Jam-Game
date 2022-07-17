using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] float _moveSpeed;
    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        _characterController.SimpleMove(new Vector3(x * _moveSpeed, 0f, 0f));
    }
}