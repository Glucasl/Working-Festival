using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    
    //Con estos metodos controlamos los botones del canvas para comproboar si tienes comida  o bebida acumulada y usarla.
    public void DecrementFood()
    {

        if (GameManager.contadorComida <= 0){

            GameManager.contadorComida = 0;
            
            
        }else if (GameManager.contadorComida > 0){
        
        // Aquí restamos 1 de comida si la comida es mayor que 0  y aumentamos la barra de hambre en 20 puntos.
        GameManager.contadorComida--;
        StatsManager.singleton._currentHunger = StatsManager.singleton._currentHunger +20;

        }
        
    }
        public void DecrementDrink()
    {
        GameManager.contadorBebida--;
        if (GameManager.contadorBebida <= 0){

            GameManager.contadorBebida = 0;
            
        }else if (GameManager.contadorBebida > 0){
        
        //Aqui hacemos lo mismo que en el metodo anterior pero con la bebida
        GameManager.contadorBebida--;
        StatsManager.singleton._currentThirst = StatsManager.singleton._currentThirst +20;

        }
    }
}
