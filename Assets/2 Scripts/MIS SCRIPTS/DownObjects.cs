using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script que permite instaciar objetos desde una altura y hacerlos caer con una fuerza determinada.
public class DownObjects : MonoBehaviour
{
    public List<GameObject> objectsToThrow;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Transform player;
    public float throwForce = 10f;
    public float throwIntervalMin = 1f;
    public float throwIntervalMax = 3f;
    public int poolSize = 10;

    private float timer;

    //Hacemos una pool de los obejtos que queremos lanzar.
    [SerializeField] private Queue<GameObject> objectPool;


    //Hacemos que con el patron de pool object se inicialize la pool con los objectos y se les aplique una posición.
    private void Start()
    {
        timer = Random.Range(throwIntervalMin, throwIntervalMax);
        objectPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, objectsToThrow.Count);
            GameObject obj = Instantiate(objectsToThrow[randomIndex]);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    //vamos lanzando los objectos de la pool entre un rango de tiempo que ha sido terminado previamente.
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ThrowFromRange();
            timer = Random.Range(throwIntervalMin, throwIntervalMax);
        }
    }

    // este metodo contiene toda la logica de las posiciones de spawn y fuerza que tendran los objectos
    private void ThrowFromRange()
    {
        if(objectPool.Count > 0) {
            GameObject obj = objectPool.Dequeue();
            obj.transform.position = new Vector3(Random.Range(startPosition.x, endPosition.x), 
                                                Random.Range(startPosition.y, endPosition.y), 
                                                Random.Range(startPosition.z, endPosition.z));
            obj.SetActive(true);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.down * throwForce, ForceMode.Impulse);
            objectPool.Enqueue(obj);
        }
    }
}