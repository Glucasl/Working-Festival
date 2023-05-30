using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Cambia de escena cuando el obejto entra en contacto con un personaje que tenga activada la etiqueta "NPC"
public class SceneTransition : MonoBehaviour
{
   public string nextScene;


   private void OnTriggerEnter(Collider other) {
    
    if (other.CompareTag("NPC")){

        SceneManager.LoadScene(0);
    }

   }



}
