using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambioFOH : MonoBehaviour
{
    [SerializeField] private GameObject Transicion;
    [SerializeField] private GameObject BlackScreen;
    [SerializeField] private float wait = 2;
    [SerializeField] private int scena;

    private DayNightController dayNightController;

    private void Start() {
        // Obtiene una referencia al componente DayNightController
        dayNightController = FindObjectOfType<DayNightController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            SingletonManager.singleton.timeDay =  dayNightController.currentTimeOfDay;
            StartCoroutine(PasarRitmo());
        }
    }

    public void PRitmo()
    {
        StartCoroutine(PasarRitmo());
    }

    public IEnumerator PasarRitmo()
    {
        Transicion.SetActive(true);
        BlackScreen.SetActive(true);
        SingletonManager.singleton.HAMBRE = StatsManager.singleton._currentHunger;
        SingletonManager.singleton.SED = StatsManager.singleton._currentThirst;
        SingletonManager.singleton.VIDA = StatsManager.singleton._currentStamina;
        Time.timeScale = 1f;
        yield return new WaitForSeconds(wait);
        Time.timeScale = 1f;
        SceneManager.LoadScene(scena);
    }
}
