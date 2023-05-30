using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoSimple : MonoBehaviour
{
    [SerializeField] GameObject panelDialogo;
    [SerializeField] GameObject punto;

    private void Start()
    {
        panelDialogo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelDialogo.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(punto);
    }

    public void MenuPausaOff()
    {
        Time.timeScale = 1;
    }
}
