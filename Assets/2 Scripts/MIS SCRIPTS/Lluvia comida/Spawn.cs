using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject asteroid;
    public float probabilidad;
    public string objeto;

    // Update is called once per frame
    void Update()
    {
        //Habrá una probabilidad del 5% de que se instancie un nuevo asteroide
        if (Random.Range(0, 100) < probabilidad)
        {
            ////Instanciamos los asteroides en una posición aleatoria de X respecto del spawner en un rango dado
            //Instantiate(asteroid,
            //    this.transform.position + new Vector3(Random.Range(-10, 10), 0, 0), Quaternion.identity);

            //Creamos una referencia a un asteroide que se pueda usar
            GameObject a = Pool.singleton.Get(objeto);
            //Si la referencia está llena
            if (a != null)
            {
                //La posición del asteroide será aleatoria relativa al creador de asteroides
                a.transform.position = this.transform.position + new Vector3(Random.Range(-10, 10), 0, 0);
                //Activamos el asteroide en concreto
                a.SetActive(true);
            }
            else
            {
                Pool.singleton.pooledItems.Add(Instantiate(asteroid, this.transform.position + new Vector3(Random.Range(-10, 10), 0, 0), Quaternion.identity));
            }
        }
    }
}
