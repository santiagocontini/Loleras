using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaSalida : MonoBehaviour
{
    public GameObject panelNota;
    public TextMeshProUGUI textoNota;

    public GameObject interactionText;

    bool jugadorCerca;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }
    }

    void Interactuar()
    {
        panelNota.SetActive(true);

        if (LlaveManager.tieneLlave)
        {
            textoNota.text =
                "Abriste la puerta...";

            Invoke(nameof(IrACancha), 1f);
        }
        else
        {
            textoNota.text =
                "La puerta está cerrada. Necesito una llave.";
        }
    }

    void IrACancha()
    {
        SceneManager.LoadScene("f5");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;

            if (interactionText != null)
            {
                interactionText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;

            if (interactionText != null)
            {
                interactionText.SetActive(false);
            }
        }
    }
}