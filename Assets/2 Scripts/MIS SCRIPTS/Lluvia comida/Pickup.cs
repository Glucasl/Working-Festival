using UnityEngine;
using UnityEngine.UI;

//Script del minijuego de lluvia de comida que contiene las funcionalidades basicas del mismo
public class Pickup : MonoBehaviour
{
        public int contadorComida;
        public int contadorBebida;
        public Text comidaTexto;
        public Text bebidaTexto;


    void Update(){

        comidaTexto.text = "Comida: " + GameManager.contadorComida;
        bebidaTexto.text = "Bebida: " + GameManager.contadorBebida;
    }

    // Si el jugador entra en contacto con la comida o la bebida destruye el objeto y guarda la cantidad de cada uno en el singleton.
    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.tag == "Comida"){

            GameManager.contadorComida = GameManager.contadorComida +1;
            if(GameManager.contadorComida >= 1){

                SingletonManager.singleton.scoreGlobal = SingletonManager.singleton.scoreGlobal + 10;
            }
            Destroy(other.gameObject);

            
        } 
        else if (other.gameObject.tag == "Bebida"){

            GameManager.contadorBebida = GameManager.contadorBebida +1;
            if(GameManager.contadorBebida >= 1){

                SingletonManager.singleton.scoreGlobal = SingletonManager.singleton.scoreGlobal + 10;
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Chatarra")
        {

            GameManager.contadorBebida = GameManager.contadorBebida - 1;
            GameManager.contadorComida = GameManager.contadorComida - 1;
            
            Destroy(other.gameObject);
        }
    }
}









