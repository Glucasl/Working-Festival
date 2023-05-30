using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Este script es el generador de comida random por la pantalla principal del videojuego.
public class Generador_Comida : MonoBehaviour
{
    public GameObject[] Comidas;
    public GameObject ComidaMostrada;
    public bool Mostrando;
    public float tiempomMin, tiempoMax;
    [SerializeField] private StatsManager _statsManagerF;

    //En el start inicializamos el metodo generar que contiene toda la logica de las posiciones de la comida
    [System.Obsolete]
    private void Start()
    {
        DestroyObject(ComidaMostrada);
        Generar();
    }

    //Con este metodo activamos el metodo comer en caso de que el jugador toque una de las comidas
    [System.Obsolete]
    void OnTriggerEnter(Collider col)
    {
        Comer();
    }

    //Con este metodo destrruimos el obejcto que el jugador toque y aumentamos sus estadisticas de hambre.
    [System.Obsolete]
    public void Comer()
    {
        
        StatsManager.singleton.ReplenishHungerThirst(20, 5);
        Mostrando = false;
        DestroyObject(ComidaMostrada);
        //Invoke("Generar", Random.Range(tiempomMin, tiempoMax));
        

    }

    //Contiene la logica del spawn random de toda la comida por el mapa principal
    void Generar()
    {
        if (!Mostrando)
        {
            Mostrando = true;
            ComidaMostrada = Instantiate(Comidas[Random.Range(0, Comidas.Length)], transform.position, Quaternion.identity);
            ComidaMostrada.transform.parent = transform;
            ComidaMostrada.transform.localScale *=2;
        }
    }
    
}
