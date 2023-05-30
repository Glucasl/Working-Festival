using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase para referenciar a los objetos del pool
[System.Serializable] //Podremos añadir estos objetos a través del inspector
public class PoolItemTYD
{
    //Objeto para meter en el pool
    public GameObject prefab;
    //Cantidad del objeto
    public int amount;
    //Variable para controlar si el pool se puede hacer más grande para este tipo de objeto
    public bool expandable;
}

public class PoolTYD : MonoBehaviour
{
    //Una referencia a una lista de objetos sobre los que vamos a usar el Pool
    public List<PoolItemTYD> items;
    //Una referencia a una lista de GO
    public List<GameObject> pooledItems;

    //Para sacar la información del Pool
    public static PoolTYD singleton;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la lista
        pooledItems = new List<GameObject>();
        //Recorremos la lista de objetos sobre los que se puede hacer el Pool
        foreach(PoolItemTYD item in items)
        {
            //Hacemos un bucle para la cantidad del objeto sobre el que hacemos el Pool
            for(int i = 0; i < item.amount; i++)
            {
                //Referenciamos el objeto instanciado
                GameObject obj = Instantiate(item.prefab);
                //Desactivamos el objeto
                obj.SetActive(false);
                //Lo añadimos a la lista de objetos que van a ser reutilizados
                pooledItems.Add(obj);
            }
        }
    }

    //Método que nos devuelve un GameObject pasándole una etiqueta por parámetro (nos devuelve un objeto de un tipo que sea reutilizable)
    public GameObject Get(string tag)
    {
        //Hacemos una pasada por la lista de objetos reutilizables
        for (int i = 0; i < pooledItems.Count; i++)
        {
            //Si el objeto concreto no está activo en la jerarquía y además su etiqueta coincide con la pasada por parámetro
            if(!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
            {
                //Devolvemos ese objeto concreto
                return pooledItems[i];
            }
        }

        //Hacemos una pasada por toda la lista de tipos de objetos del pool
        foreach (PoolItemTYD item in items)
        {
            //Si la etiqueta del objeto que buscamos coincide con la del tipo de objeto sobre el que queremos trabajar, y es ampliable en el Pool
            if (item.prefab.tag == tag && item.expandable)
            {
                //Instaciamos un nuevo objeto de ese tipo
                GameObject obj = Instantiate(item.prefab);
                //Desactivamos ese objeto en concreto con la finalidad de que pueda ser reutilizado
                obj.SetActive(false);
                //Añadimos ese objeto en concreto a la lista de objetos reutilizables
                pooledItems.Add(obj);
                //Nos devuelve este objeto en concreto para ser utilizado
                return obj;
            }
        }
        //De lo contrario nos devuelve una referencia vacía
        return null;
    }
}
