using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Script con todas las funcionalidades del juego de encontrar parejas
public class CrearCartas : MonoBehaviour
{

    [Header("Parametros")]
    public GameObject cartaPrefab;
    public int ancho;
    public Transform cartasParent;
    private List<GameObject> cartas = new List<GameObject>();

    [Header("Texturas")]
    public Material[] maeriales;
    public Texture2D[] texturas;

    [Header("Contadores")]
    public int contadorClicks;
    public Text textContadorIntentos;
    public int nueroParejasEncontradas;

    public Carta cartaMostrada;
    public bool sePuedeMostra = true;

    public InterfazParejas interfazParejas;

    void Start()
    {
        Crear();
        //interfazParejas.ActivarCrono();
        
    }
    //Metodo en el cual se crean las cartas y se les asigna una posicion
    public void Crear()
    {
        int cont = 0;
        for(int i = 0; i < ancho; i++)
        {
            for(int x = 0; x < ancho; x++)
            {
                float factor = 8.0f/ancho;
                Vector3 posicionTemp = new Vector3(x * factor, 0, i * factor);

                GameObject cartaTemp = Instantiate(cartaPrefab,posicionTemp, Quaternion.Euler(new Vector3(0,180,0)));

                cartaTemp.transform.localScale *= factor;

                cartas.Add(cartaTemp);

                cartaTemp.GetComponent<Carta>().posicionOriginal = posicionTemp;

                cartaTemp.transform.parent = cartasParent;

                cont++;
            }
        }
        AsignarTexturas();
        Barajar();
    }

    //metodo que asigna la textura de cada una de las cartas del juego
    void AsignarTexturas()
    {
        int[] arrayTemp = new int[texturas.Length];

        for (int i = 0; i < texturas.Length-1; i++)
        {
            arrayTemp[i] = i;
        }

        for (int t = 0; t < arrayTemp.Length; t++)
        {
            int tmp = arrayTemp[t];
            int r = Random.Range(t, arrayTemp.Length);
            arrayTemp[t] = arrayTemp[r];
            arrayTemp[r] = tmp;
        }

        int[] arrayDefinitivo = new int[ancho * ancho];

        for (int i = 0; i < arrayDefinitivo.Length; i++)
        {
            arrayDefinitivo[i] = arrayTemp[i];
        }

        for (int i = 0; i < arrayDefinitivo.Length; i++)
        {
            cartas[i].GetComponent<Carta>().AsignarTextura(texturas[(arrayDefinitivo[i/2])]);
            cartas[i].GetComponent<Carta>().idCarta = i / 2;
        }
    }

    //Metodo con el cual se mezclan las cartas 
    void Barajar()
    {
        int aleatorio;
        for(int i = 0; i < cartas.Count; i++)
        {
            aleatorio = Random.Range(i, cartas.Count);

            cartas[i].transform.position = cartas[aleatorio].transform.position;
            cartas[aleatorio].transform.position = cartas[i].GetComponent<Carta>().posicionOriginal;

            cartas[i].GetComponent<Carta>().posicionOriginal = cartas[i].transform.position;
            cartas[aleatorio].GetComponent<Carta>().posicionOriginal = cartas[aleatorio].transform.position;
        }
    }

    //Este metodo contiene la funcionalidad al hacer click sobre una de las cartas para revelar su cara
    public void HacerClick(Carta _carta)
    {
        if (cartaMostrada == null)
        {
            cartaMostrada = _carta;
        }
        else
        {
            contadorClicks++;
            ActualizarUI();

            if (CompararCartas(_carta.gameObject, cartaMostrada.gameObject))
            {
                print("Enhorabuena, has encontrado una pareja");
                nueroParejasEncontradas++;
                if(nueroParejasEncontradas == cartas.Count / 2)
                {
                    print("Enhorabuena, ganaste");
                    interfazParejas.MostrarMenuGanador();
                }
            }
            else
            {
                _carta.EsconderCarta();
                cartaMostrada.EsconderCarta();
            }
            cartaMostrada = null;
        }  
    }

    //El metodo contiene la logica de compara las cartas para ver si se ha encontrado una pareja
    public bool CompararCartas(GameObject carta1, GameObject carta2)
    {
        bool resultado;
        //if (carta1.GetComponent<MeshRenderer>().material.mainTexture == carta2.GetComponent<MeshRenderer>().material.mainTexture)
        if (carta1.GetComponent<Carta>().idCarta == carta2.GetComponent<Carta>().idCarta)
        {
            resultado = true;
        }
        else
        {
            resultado = false;
        }
        return resultado;
    }

    //En este metodo actualizamos la UI poniendo los intentos que son los clicks realizados
    public void ActualizarUI()
    {
        textContadorIntentos.text = "Intentos: " + contadorClicks;
    }
}
