using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitarObjetos : MonoBehaviour
{
    public ParticleSystem explosion;

    private void OnTriggerEnter(Collider other)
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
