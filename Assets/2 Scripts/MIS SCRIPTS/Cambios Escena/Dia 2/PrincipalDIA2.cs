using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrincipalDIA2 : MonoBehaviour
{
    [SerializeField] private GameObject Transicion;
    [SerializeField] private GameObject BlackScreen;
    [SerializeField] private float wait = 2;
    public int numeroEscena;

    public void Start()
    {
        SingletonManager.singleton.timeDay = 0;
        Transicion.SetActive(false);
        BlackScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(PasarPrincipal());
        }
    }

    public void PPrincipal()
    {
        StartCoroutine(PasarPrincipal());
    }
    public IEnumerator PasarPrincipal()
    {
        Transicion.SetActive(true);
        BlackScreen.SetActive(true);
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(numeroEscena);
    }
    public void PInicial()
    {
        StartCoroutine(PasarInicio());
    }

    public IEnumerator PasarInicio()
    {
        Transicion.SetActive(true);
        BlackScreen.SetActive(true);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(wait);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
