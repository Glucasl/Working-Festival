using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    
    public float fadeInTime;
    public float fadeOutTime;

    private Image fadePanel;
    private Color currentColor = Color.black;


    void Start()
    {
        fadePanel = GetComponent<Image>();
        fadePanel.color = new Color(0, 0, 0, 1);
    }

   public void FadeIn(){

        StartCoroutine(FadeTo(0f, fadeInTime));
   }

   public void FadeOut(){

        StartCoroutine(FadeTo(1f, fadeOutTime));
   }

    IEnumerator FadeTo(float aValue, float aTime){

            float alpha = fadePanel.color.a;
            for (float t = 0.0f; t < 1.0f; t+= Time.deltaTime / aTime){

                Color newColor = new Color (0, 0, 0, Mathf.Lerp(alpha, aValue, t));
                fadePanel.color = newColor;

                yield return null;
            }

    }

}
