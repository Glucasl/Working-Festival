using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script con todas las funcionalidades  de la carta 
public class Carta : MonoBehaviour
{
    [Header("Datos")]
    public int idCarta = 0;
    public Vector3 posicionOriginal;

    [Header("Texturas")]
    public Texture2D texturaAnvers;
    public Texture2D texturaReverso;

    [Header("Delay")]
    public float tiempoDelay;
    GameObject crearCartas;
    public bool mostrando;

    [Header("Interface")]
    public GameObject interfaceParejas;

    private void Awake()
    {
        crearCartas = GameObject.Find("Scripts");
        interfaceParejas = GameObject.Find("Scripts");
    }

    private void Start()
    {
        EsconderCarta();
    }

    void OnMouseDown()
    {
        if(!interfaceParejas.GetComponent<InterfazParejas>(). menuMostrado)
        MostrarCarta();
    }

    public void AsignarTextura(Texture2D _textura)
    {
        texturaAnvers = _textura;
    } 
    
    public void MostrarCarta()
    {
        if (!mostrando && crearCartas.GetComponent<CrearCartas>().sePuedeMostra)
        {
            mostrando = true;
            GetComponent<MeshRenderer>().material.mainTexture = texturaAnvers;
            crearCartas.GetComponent<CrearCartas>().HacerClick(this);
        }
        
    }

    public void EsconderCarta()
    {
        Invoke("Esconder", tiempoDelay);
        crearCartas.GetComponent<CrearCartas>().sePuedeMostra = false;
    }
    void Esconder()
    {
        GetComponent<MeshRenderer>().material.mainTexture = texturaReverso;
        mostrando = false;
        crearCartas.GetComponent<CrearCartas>().sePuedeMostra = true;
    }
}
