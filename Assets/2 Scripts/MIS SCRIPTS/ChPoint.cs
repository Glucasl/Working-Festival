using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChPoint : MonoBehaviour
{
    public Transform siguienteNodo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="NPC")
        {
            other.gameObject.GetComponent<ControladorMaya>().objetivo = siguienteNodo;
        }
    }

}
