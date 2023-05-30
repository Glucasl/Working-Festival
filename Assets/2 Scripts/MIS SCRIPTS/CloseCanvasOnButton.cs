using UnityEngine;
using UnityEngine.UI;

public class CloseCanvasOnButton : MonoBehaviour
{
    public Canvas canvas;
    public Button closeButton;

    private void Start()
    {
        closeButton.onClick.AddListener(CloseCanvas);
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false);
    }
}