using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocaryDestruirPrueba : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject zone;

    private void Awake()
    {
        zone = GameObject.Find("PushZone");
    }

    private void OnBecameInvisible()
    {
        //Destruimos el objeto al hacerse invisible
        //Destroy(this.gameObject);

        //Desactivamos el objeto al hacerse invisible
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        GetComponent<Rigidbody>().AddForce(zone.GetComponent<PushArea>().direction * zone.GetComponent<PushArea>().strenght);
    }

    private void OnMouseDown()
    {
        this.gameObject.SetActive(false);
    }
}
