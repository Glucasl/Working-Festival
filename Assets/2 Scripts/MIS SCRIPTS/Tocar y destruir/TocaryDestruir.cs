using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocaryDestruir : MonoBehaviour
{
    private Rigidbody rb;

    private float rangoX = 4.0f;
    private float posY = -1.0f;
    private float minVelocidad = 12.0f;
    private float maxVelocidad = 16.0f;
    private float fuerzaTorsion = 10.0f;
    public GameObject zone;

    private void Awake()
    {
        zone = GameObject.Find("PushZone");
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        transform.position = new Vector3(Random.Range(-rangoX, rangoX), posY);

        rb.AddForce(FuerzaImpulso(), ForceMode.Impulse);

        rb.AddTorque(ValorTorsion(), ValorTorsion(), ValorTorsion(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(zone.GetComponent<PushArea>().direction * zone.GetComponent<PushArea>().strenght);
    }

    Vector3 PosGeneracion()
    {
        return new Vector3(Random.Range(-rangoX, rangoX), posY);
    }

    Vector3 FuerzaImpulso()
    {
        return Vector3.up * Random.Range(minVelocidad, maxVelocidad);
    }

    float ValorTorsion()
    {
        return Random.Range(-fuerzaTorsion, fuerzaTorsion);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
