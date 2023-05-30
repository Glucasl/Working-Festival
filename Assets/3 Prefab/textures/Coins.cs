using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject coins;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SingletonManager.singleton.Contador += 1;
            //DataBaseController.InsertarPuntos(1);
            Destroy(this.gameObject);
        }
    }
}
