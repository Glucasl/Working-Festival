using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuitButton : MonoBehaviour
{
    [SerializeField] private GameObject Transicion;
    [SerializeField] private GameObject BlackScreen;
    [SerializeField] private float wait = 2;

    public void SalirInicio()
    {
        StartCoroutine(Inicio());
    }

    public IEnumerator Inicio()
    {
        Transicion.SetActive(true);
        BlackScreen.SetActive(true);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(wait);
        Time.timeScale = 1f;
        SingletonManager.singleton.Contador = 0;
        SceneManager.LoadScene(0);
    }
}
