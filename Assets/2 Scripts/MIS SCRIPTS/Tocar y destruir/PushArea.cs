using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushArea : MonoBehaviour
{
    public static PushArea instance;
    public float strenght;
    public Vector3 direction;

    private void Awake()
    {
        instance = this;
    }
}
