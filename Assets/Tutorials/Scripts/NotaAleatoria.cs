using TMPro;
using UnityEngine;

public class NotaAleatoria : MonoBehaviour
{
    public GameObject panelNota;
    public TextMeshProUGUI textoNota;

    [TextArea(2, 5)]
    public string[] frases;

    public int idObjeto;
    public GameObject iconoLlave;

    public GameObject interactionText;

    bool jugadorCerca;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            MostrarFrase();
        }

        if (panelNota != null &&
            panelNota.activeSelf &&
            Input.GetKeyDown(KeyCode.Escape))
        {
            panelNota.SetActive(false);
        }
    }

    void MostrarFrase()
    {
        if (!LlaveManager.tieneLlave &&
            idObjeto == LlaveManager.esconditeLlave)
        {
            LlaveManager.tieneLlave = true;

            textoNota.text =
                "¡Encontraste una llave!";

            panelNota.SetActive(true);

            if (iconoLlave != null)
            {
                iconoLlave.SetActive(true);
            }

            return;
        }

        int indice =
            Random.Range(0, frases.Length);

        textoNota.text =
            frases[indice];

        panelNota.SetActive(true);
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