using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    public static Pausa instance;
    bool active;
    
    [SerializeField] GameObject pausa;
    [SerializeField] GameObject HUDjuego;

    // Start is called before the first frame update
    void Start()
    {
        pausa.SetActive(false);
        HUDjuego.SetActive(true);
        
    }

    public void MenuPausaOn()
    {
        pausa.SetActive(true);
        HUDjuego.SetActive(false);
        Time.timeScale = 0;
    }
    public void MenuPausaOff()
    {
        pausa.SetActive(false);
        HUDjuego.SetActive(true);
        Time.timeScale = 1;
    }
}
