using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int contadorComida;
    public static int contadorBebida;


    private void Awake()
    {
        // Asegurar que solo exista una instancia de GameManager en la escena
        DontDestroyOnLoad(this.gameObject);
    }

}

