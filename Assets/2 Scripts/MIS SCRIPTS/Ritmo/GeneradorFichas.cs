using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorFichas : MonoBehaviour
{
    public GameObject[] flechas;
    private float tiempoEntreFlechas;
    public float comienzoDeTiempo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoEntreFlechas <= 0)
        {
            int random = Random.Range(0, flechas.Length);
            Instantiate(flechas[random], transform.position, Quaternion.identity);

            tiempoEntreFlechas = comienzoDeTiempo;
        }
        else
        {
            tiempoEntreFlechas -= Time.deltaTime;
        }
    }
}
