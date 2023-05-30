using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

// Script que contiene la interfaz del juego de encontrar parejas
public class InterfazParejas : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuganador;
    public bool menuMostrado;
    public Text txtmenuGandor;
    public int scena;

    [SerializeField] private GameObject Transicion;
    [SerializeField] private GameObject BlackScreen;
    [SerializeField] private float wait = 2;

    public void MostrarMenu()
    {
        menu.SetActive(true);
        menuMostrado = true;
    }
    
    public void MostrarMenuGanador()
    {
        menuganador.SetActive(true);
        menuMostrado = true;
        SingletonManager.singleton.scoreGlobal = 100;
    }

    public void EsconderMenu()
    {
        menu.SetActive(false);
        menuMostrado = false;
    }
    
    public void VolverAlPrincpal()
    {
        StartCoroutine(Principal());
    }

    public IEnumerator Principal()
    {
        Transicion.SetActive(true);
        BlackScreen.SetActive(true);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(wait);
        Time.timeScale = 1f;
        SceneManager.LoadScene(scena);
    }
}
