using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    public string[] dialogues;
    public Text dialogText;
    public GameObject dialogPanel;
    public float dialogueDelay = 3f; // Tiempo de espera antes de mostrar el siguiente diálogo
    public float cooldownTime = 10f; // Tiempo de espera después de completar los diálogos antes de poder iniciarlos nuevamente

    private bool triggered = false;
    private bool dialoguesCompleted = false;
    private int currentDialogueIndex = 0;
    private float cooldownTimer = 0f;


    private void Start()
    {
        dialogPanel.SetActive(false);
    }

    private void Update()
    {
        if (dialoguesCompleted)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0f)
            {
                cooldownTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            if (dialoguesCompleted && cooldownTimer > 0f)
            {
                return; // Si los diálogos se completaron y el tiempo de espera aún no ha terminado, no inicia los diálogos nuevamente
            }

            if (dialoguesCompleted)
            {
                currentDialogueIndex = 0; // Reinicia los diálogos
            }

            triggered = true;
            ShowDialog();
        }
    }

    private void ShowDialog()
    {
        dialogPanel.SetActive(true);
        dialogText.text = dialogues[currentDialogueIndex];
        StartCoroutine(ContinueDialogAfterDelay());
    }

    private System.Collections.IEnumerator ContinueDialogAfterDelay()
    {
        yield return new WaitForSeconds(dialogueDelay);

        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogText.text = dialogues[currentDialogueIndex];
            StartCoroutine(ContinueDialogAfterDelay());
        }
        else
        {
            dialoguesCompleted = true;
            cooldownTimer = cooldownTime;
            dialogPanel.SetActive(false);
            dialogText.text = string.Empty;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = false;
        }
    }
}






