using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador_Comida1_LLuvia : MonoBehaviour
{
    public GameObject[] Comidas;
    public GameObject ComidaMostrada;
    public bool Mostrando;
    //public float tiempomMin, tiempoMax, hambreSumada;
    [SerializeField] private StatsManager _statsManagerF;

    [System.Obsolete]
    private void Start()
    {
        Generar();
    }

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
