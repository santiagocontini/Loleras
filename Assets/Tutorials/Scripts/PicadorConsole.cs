using UnityEngine;
using UnityEngine.SceneManagement;

public class PicadorConsole : MonoBehaviour
{
    private bool playerNear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MinijuegoArmado", LoadSceneMode.Additive);
        }
    }
}