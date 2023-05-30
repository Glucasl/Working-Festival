using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


//En este script creamos un controlador de ciclo de dia y noche.
public class DayNightController : MonoBehaviour {

    public Light sun;
    public float secondsInFullDay = 120f;
    public GameObject luces;
    public int pasarNivel;
    public int scoreScene;
    
    [Range(0,1)]
    public float currentTimeOfDay = 0.28f;

    [HideInInspector]
    public float timeMultiplier = 1f;

    float sunInitialIntensity = 0.28f;


    [SerializeField] private GameObject Transicion;
    [SerializeField] private GameObject BlackScreen;
    [SerializeField] private float wait = 2;

    void Awake() {
        
        currentTimeOfDay = SingletonManager.singleton.timeDay;
    }
    //Iniciamos la intesidad del sol
    void Start() {
        sunInitialIntensity = sun.intensity;
    }

    //actualizamos la posicion del sol y el paso del dia
    void Update() {

        UpdateSun();

 
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;


        if (currentTimeOfDay >= 1) {
            currentTimeOfDay = 0;
            StartCoroutine(Inicio());
        }

         if (Input.GetKeyDown(KeyCode.F))
        {
             SceneManager.LoadScene(10);
        }
    }

    //Este metodo actualiza la intensidad y posicion del sol dependiendo del tiempo del dia que haya pasado, para ello variamos la intesidad en 3 fases, dia, tarde y noche.
    void UpdateSun() {

        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);


        float intensityMultiplier = 1;
       
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
            intensityMultiplier = 0;
            
        }
        
        else if (currentTimeOfDay <= 0.25f) {

            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
            luces.SetActive(false);
        }

        else if (currentTimeOfDay >= 0.73f) {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));

            luces.SetActive(true);
            
             
        } 
        
        else if(currentTimeOfDay == 0.1f) 
        {
            
             
            
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;


    }

    public IEnumerator Inicio()
    {
        Transicion.SetActive(true);
        BlackScreen.SetActive(true);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(wait);
        Time.timeScale = 1f;
        //SingletonManager.singleton.Contador = 0;
        if (SingletonManager.singleton.scoreGlobal >= pasarNivel){
            SingletonManager.singleton.VIDA = 100;
            SingletonManager.singleton.HAMBRE = 100;
            SingletonManager.singleton.SED = 100;
            SceneManager.LoadScene(scoreScene);
        }else {

            SceneManager.LoadScene(6);
        }
        
    }
}