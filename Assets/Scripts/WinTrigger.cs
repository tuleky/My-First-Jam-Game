using System;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private WinPanel _winPanel;
    
    void OnTriggerEnter(Collider other)
    {
        _winPanel.EnableWinPanel();
    }
}