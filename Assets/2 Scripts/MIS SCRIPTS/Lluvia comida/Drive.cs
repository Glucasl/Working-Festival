using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script para el movmiento del personaje en el juego de Lluvia de comida
public class Drive : MonoBehaviour
{
    public float speed = 10.0f;

    void FixedUpdate()
    {
        float translation = SimpleInput.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        transform.Translate(translation, 0, 0);
        // Limita el rango del player en el eje X entre 11 y -11
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11, 11), transform.position.y, transform.position.z);
    }
   
}