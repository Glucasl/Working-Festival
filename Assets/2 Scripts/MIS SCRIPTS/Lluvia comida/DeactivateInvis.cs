using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInvis : MonoBehaviour
{
    //M�todo que detecta cuando el objeto se sale de la zona que ve la c�mara
    private void OnBecameInvisible()
    {
        //Destruimos el objeto al hacerse invisible
        //Destroy(this.gameObject);

        //Desactivamos el objeto al hacerse invisible
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "Comida")
            {
                StatsManager.singleton.comida = StatsManager.singleton.comida + 1;
            }
            else if (this.gameObject.tag == "Chatarra")
            {
                StatsManager.singleton.comida = StatsManager.singleton.comida - 1;
                StatsManager.singleton.bebida = StatsManager.singleton.bebida - 1;

            }
            else if (this.gameObject.tag == "Bebida")
            {
                StatsManager.singleton.bebida = StatsManager.singleton.bebida + 1;
            }
            else if (this.gameObject.tag == "modena")
            {
                SingletonManager.singleton.Contador = SingletonManager.singleton.Contador + 1;
            }
            this.gameObject.SetActive(false);
        }
    }
}
