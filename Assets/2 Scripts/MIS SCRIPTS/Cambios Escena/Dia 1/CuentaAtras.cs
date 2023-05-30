using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

//Este script tiene el cronometro de los minijuegos.
public class CuentaAtras : MonoBehaviour
{
    public float tiempi;
    public float tiempiMin;
    public Text crono;
    TimeSpan tiempo;
    public int Scena;

    [SerializeField] private GameObject Transicion;
    [SerializeField] private GameObject BlackScreen;
    [SerializeField] private float wait = 2;

    
    private void Start()
    {
       
        while (tiempi >= 60)
        {
            tiempiMin++;
            tiempi = tiempi - 60;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        //Aqui actualizzamos el cronometro y comprobamos que si valor es 0 el minijuego termina y se carga la escena principal
        tiempi = tiempi - Time.deltaTime;
        ActualizarCronometro();
        if (tiempi <= 0)
        {
            if (tiempiMin > 0)
            {
                tiempiMin--;
                tiempi = 59;
            }
            else
            {
                StartCoroutine(Principal());
            }

            
        }
    }
    public void ActualizarCronometro()
    {

        int a = Convert.ToInt32(tiempi);
        
        
        crono.text = tiempiMin.ToString() + " : " + a.ToString();
       
    }

    public void IrPrincipal()
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
        SceneManager.LoadScene(Scena);
        
    }
}
