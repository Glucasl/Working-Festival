using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorJuego : MonoBehaviour
{
    public List<GameObject> objtivos;

    private float retrasoGeneracion = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarObjetivos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerarObjetivos()
    {
        while (true)
        {
            yield return new WaitForSeconds(retrasoGeneracion);
            int index = Random.Range(0, objtivos.Count);
            Instantiate(objtivos[index]);
        }
        
    }

}
