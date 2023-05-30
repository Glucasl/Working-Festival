using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
  [SerializeField] string nextLevelName;

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Debug.Log("Level complete");

      StoneMovement playerMovement = other.GetComponent<StoneMovement>();

      if (playerMovement != null)
      {
        playerMovement.DisablePlayerInput();
      }

      StartCoroutine("LoadLevel");
    }
  }

  IEnumerator LoadLevel()
  {
    yield return new WaitForSeconds(2);

    SceneManager.LoadScene(nextLevelName);
  }
}
