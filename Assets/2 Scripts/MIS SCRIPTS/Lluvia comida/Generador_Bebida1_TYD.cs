using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador_Bebida1_TYD : MonoBehaviour
{
    public GameObject[] Bebidas;
    public GameObject BebidaMostrada;
    public bool Mostrando;
    [SerializeField] private StatsManager _statsManagerD;

    [System.Obsolete]
    private void Start()
    {
        DestroyObject(BebidaMostrada);
        Generar();
    }
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
