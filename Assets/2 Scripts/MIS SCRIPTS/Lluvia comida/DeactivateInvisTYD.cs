using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInvisTYD : MonoBehaviour
{
    //M�todo que detecta cuando el objeto se sale de la zona que ve la c�mara
    private void OnBecameInvisible()
    {
        //Destruimos el objeto al hacerse invisible
        //Destroy(this.gameObject);

        //Desactivamos el objeto al hacerse invisible
        this.gameObject.SetActive(false);
    }

   
}
