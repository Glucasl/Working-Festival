using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SimpleInput.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
        }
        if (SimpleInput.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }
}
