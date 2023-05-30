using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{    
    public float wait= 2;
    public GameObject Transicion, BlackScreen;
    public int scena;

    public void Start()
    {        
        Transicion.SetActive(false);
        BlackScreen.SetActive(false);
    }
    public void Partida()
    {
        StartCoroutine(PartidaCo());        
    }
    public IEnumerator PartidaCo()
    {        
        Transicion.SetActive(true);
        BlackScreen.SetActive(true);
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene("TEST_AREA_ROOTMOTION");
    }
    public void MPrincipal()
    {
        //Application.LoadLevel(scena);
       StartCoroutine(MPrincipalCo());
    }

    public IEnumerator MPrincipalCo()
    {
        Transicion.SetActive(true);
        BlackScreen.SetActive(true);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(wait);        
        Time.timeScale = 1f;
        SceneManager.LoadScene(scena);
    }

}
