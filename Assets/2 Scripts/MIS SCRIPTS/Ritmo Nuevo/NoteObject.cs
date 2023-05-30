using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed, pressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    Vector3 lugar;


    // Update is called once per frame
    void Update()
    {
        if (SimpleInput.GetKeyDown(keyToPress))
        {
            presionoTecla();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D dos)
    {
        if (dos.tag == "Limit")
        {

            canBePressed = false;
            lugar = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            GameManagerRitmo.instance.NoteMissed();
            Instantiate(missEffect, lugar, missEffect.transform.rotation);
        }
    }

    public void presionoTecla()
    {

        if (canBePressed)
        {
            gameObject.SetActive(false);

            //GameManagerRitmo.instance.NoteHit();

            if (Mathf.Abs(transform.position.y) > 0.25f)
            {
                Debug.Log("Hit");
                GameManagerRitmo.instance.NormalHit();
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            }
            else if (Mathf.Abs(transform.position.y) > 0.05f)
            {
                Debug.Log("Good");
                GameManagerRitmo.instance.GoodHit();
                Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
            }
            else
            {
                Debug.Log("Perfect");
                GameManagerRitmo.instance.PerfectHit();
                Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
            }
        }
    }
}
