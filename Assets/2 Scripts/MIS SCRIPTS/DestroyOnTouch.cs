using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Un script que nos permitira destruir los objectos que queramos al entrar en un trigger, podemos reutilizarlo en diferentes minijuegos.
public class DestroyOnTouch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
