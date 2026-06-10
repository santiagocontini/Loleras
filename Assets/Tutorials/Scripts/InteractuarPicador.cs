using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractuarPicador : MonoBehaviour
{
    private bool jugadorCerca = false;

    void Update()
    {
        if (jugadorCerca)
        {
            Debug.Log("Jugador cerca");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Presionó E");

                SceneManager.LoadScene("MinijuegoArmado");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;

            Debug.Log("Entró al trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;

            Debug.Log("Salió del trigger");
        }
    }
}