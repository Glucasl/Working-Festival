using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInvisTYD : MonoBehaviour
{
    //Método que detecta cuando el objeto se sale de la zona que ve la cámara
    private void OnBecameInvisible()
    {
        //Destruimos el objeto al hacerse invisible
        //Destroy(this.gameObject);

        //Desactivamos el objeto al hacerse invisible
        this.gameObject.SetActive(false);
    }

   
}
