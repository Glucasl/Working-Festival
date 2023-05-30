using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorMaya : MonoBehaviour
{
    public NavMeshAgent miAgente;
    public Transform objetivo;
    public Transform[] nodos;
    public float offSet = 1;

    private int posicionActual;

    // Start is called before the first frame update
    void Start()
    {
        if(miAgente == null)
        {
            miAgente = this.gameObject.GetComponent<NavMeshAgent>();
        }
        objetivo = nodos[0];
    }

    // Update is called once per frame
    void Update()
    {
        miAgente.SetDestination(objetivo.position);
        Vector3 distancia;
        distancia = objetivo.position - transform.position;
        if(distancia.magnitude <= offSet)
        {
            posicionActual++;
            if(posicionActual >= nodos.Length)
            {
                posicionActual = 0;
            }
            objetivo = nodos[posicionActual];
        }
    }
}
