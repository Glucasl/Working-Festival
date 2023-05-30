using UnityEngine;
using UnityEngine.UI;


//Este script nos permite activar o desactivar el canvas.
public class OpenCanvasOnClick : MonoBehaviour
{
    public Canvas canvas;
    public Canvas interfacex;

    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
            interfacex.gameObject.SetActive(false);
        }
    }
}