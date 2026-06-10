using TMPro;
using UnityEngine;

public class AmigoDiversion : MonoBehaviour
{
    public TextMeshProUGUI diversionText;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

   public int diversion = 0;

public bool pausado = false;

    private float dialogoTimer = 0f;

    void Start()
    {
        dialoguePanel.SetActive(false);

        diversionText.text =
            "Diversión Juan: " + diversion;
    }

    void Update()
    {
        if (dialoguePanel.activeSelf)
        {
            dialogoTimer -= Time.deltaTime;

            if (dialogoTimer <= 0f)
            {
                dialoguePanel.SetActive(false);
            }
        }

        if (ResultadoArmado.mostrarResultado)
        {
            MostrarResultadoArmado();

            ResultadoArmado.mostrarResultado = false;
        }
    }

    public void MostrarDialogo(string mensaje)
    {
        dialoguePanel.SetActive(true);

        dialogueText.text = mensaje;

        dialogoTimer = 4f;
    }

    public void AgregarDiversion(int cantidad)
    {
        diversion += cantidad;

        if (diversion > 100)
        {
            diversion = 100;
        }

        diversionText.text =
            "Diversión Juan: " + diversion;

        if (diversion >= 100)
        {
            MostrarDialogo("La mejor juntada de la historia.");
        }
    }

    void MostrarResultadoArmado()
    {
        int puntaje = ResultadoArmado.ultimoPuntaje;

        if (puntaje >= 90)
        {
            MostrarDialogo("Uh esto si que pega.");
            AgregarDiversion(30);
        }
        else if (puntaje >= 75)
        {
            MostrarDialogo("Muy bueno, quedó re prolijo.");
            AgregarDiversion(20);
        }
        else if (puntaje >= 60)
        {
            MostrarDialogo("Gracias.");
            AgregarDiversion(10);
        }
        else if (puntaje >= 40)
        {
            MostrarDialogo("Armaste con las sobras de las tucas rata.");
            AgregarDiversion(5);
        }
        else
        {
            MostrarDialogo("¿Qué compraste? Esto es paragua.");
        }

        ResultadoArmado.ultimoPuntaje = 0;
    }
}