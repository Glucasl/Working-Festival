using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Con este script desactivamos cualquier objeto al hacer click sobre un objeto.
public class ObjectDisappear : MonoBehaviour
{
 

    private void OnMouseDown() {
        
        Destroy(gameObject);

    }

}
