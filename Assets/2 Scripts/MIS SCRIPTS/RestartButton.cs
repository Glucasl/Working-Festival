using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartButton : MonoBehaviour
{
    // Este Boton nos permite reinciar el juego reinciando el dinero del juego.
    public Button restartButton;

    [SerializeField] private GameObject Transicion;
    [SerializeField] private GameObject BlackScreen;
    [SerializeField] private float wait = 2;

    private void Start() {
        
        SingletonManager.singleton.timeDay = 0;
    }

    public void Pcomida()
    {
        StartCoroutine(AD());
    }

    public IEnumerator AD()
    {
        Transicion.SetActive(true);
        BlackScreen.SetActive(true);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(wait);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}