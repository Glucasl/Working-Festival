using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que nosd permite lanzar objetos aplicandoles una fuerza
public class ThrowObjects : MonoBehaviour
{
    public List<GameObject> objectsToThrow;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform player;
    public float throwForce = 10f;
    public float throwIntervalMin = 1f;
    public float throwIntervalMax = 3f;
    public int poolSize = 10;

    private float timer;
    private Transform[] spawnPoints;
    [SerializeField] private Queue<GameObject> objectPool;


    // En el start tenemos un bucle el cual coje los obejctos de la pool y los pone en cola para ser usados
    private void Start()
    {
        timer = Random.Range(throwIntervalMin, throwIntervalMax);
        spawnPoints = new Transform[] { spawnPoint1, spawnPoint2, spawnPoint3, spawnPoint4 };
        objectPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, objectsToThrow.Count);
            GameObject obj = Instantiate(objectsToThrow[randomIndex]);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    // En el ipdate vamos lanzando los obejtos de la pool en el tiempo que se le haya dicho aplicandoles una fuerza
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            ThrowFromPoint(spawnPoints[randomIndex]);
            timer = Random.Range(throwIntervalMin, throwIntervalMax);
        }
    }

    //Metodo que contiene la fuerza de lanzamiento  y posición de los lazamientos
    private void ThrowFromPoint(Transform spawnPoint)
    {
        GameObject obj = objectPool.Dequeue();
        obj.transform.position = spawnPoint.position;
        obj.transform.rotation = spawnPoint.rotation;
        obj.SetActive(true);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce((player.position - spawnPoint.position).normalized * throwForce, ForceMode.Impulse);
        objectPool.Enqueue(obj);
    }
}