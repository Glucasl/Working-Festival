using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Con estre script creamos un generador de bebida para instaciar las bebidas que aprecen en la pantalla principal del juego.
public class Generador_Bebida : MonoBehaviour
{
    public GameObject[] Bebidas;
    public GameObject BebidaMostrada;
    public bool Mostrando;
    public float tiempomMin, tiempoMax;
    [SerializeField] private StatsManager _statsManagerD;

    // En el start activamos el metodo generar que es el cual genera toda la logica de la instaciación.
    [System.Obsolete]
    private void Start()
    {
       // DestroyObject(BebidaMostrada);
        BebidaMostrada.SetActive(false);
        Generar();
    }

    //Si el jugador entra contacto con una bebida se aplocara el metodo comer.
    [System.Obsolete]
    void OnTriggerEnter(Collider col)
    {

        Comer();
    }

    //El metodo comer destruye el objeto cuando el player entra en contacto con el y aumenta las estadisticas de sed del jugador
    [System.Obsolete]
    public void Comer()
    {
        StatsManager.singleton.ReplenishHungerThirst(5, 20);
        Mostrando = false;
        DestroyObject(BebidaMostrada);
        //Invoke("Generar", Random.Range(tiempomMin, tiempoMax));
    }

    //Este metodo contiene la logica del spawn alatorio de cada bebida por la pantalla principal.
    void Generar()
    {
        if (!Mostrando)
        {
            Mostrando = true;
            BebidaMostrada = Instantiate(Bebidas[Random.Range(0, Bebidas.Length)], transform.position, Quaternion.identity);
            BebidaMostrada.transform.parent = transform;
            BebidaMostrada.transform.localScale *= 2;
        }
    }
    
}
