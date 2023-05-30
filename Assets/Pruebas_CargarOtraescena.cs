using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas_CargarOtraescena : MonoBehaviour
{
    public int leveltoLoad;
    // Start is called before the first frame update
   public void LoadLevel()
    {

        Application.LoadLevel(leveltoLoad);
    }
}
