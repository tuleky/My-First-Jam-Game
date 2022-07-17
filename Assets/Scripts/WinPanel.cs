using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    public void EnableWinPanel()
    {
        _canvas.gameObject.SetActive(true);
    }
}