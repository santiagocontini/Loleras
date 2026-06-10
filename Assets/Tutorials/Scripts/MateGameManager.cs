using TMPro;
using UnityEngine;

public class MateGameManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI barText;

    public GameObject mateGame;

    private PlayerMovement playerMovement;

    private float posicion;
    private bool derecha;
    private bool jugando;

    void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    void OnEnable()
    {
        ReiniciarJuego();
    }

    void ReiniciarJuego()
    {
        posicion = -10f;
        derecha = true;
        jugando = true;

        resultText.text = "PRESIONÁ ESPACIO";

        MostrarBarra();
    }

    void Update()
    {
        if (!jugando)
            return;

        if (derecha)
            posicion += 30f * Time.deltaTime;
        else
            posicion -= 30f * Time.deltaTime;

        if (posicion > 10f)
            derecha = false;

        if (posicion < -10f)
            derecha = true;

        MostrarBarra();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Evaluar();
        }
    }

    void MostrarBarra()
    {
        int indice = Mathf.RoundToInt(posicion + 10);

        string barra = "";

        for (int i = 0; i < 21; i++)
        {
            if (i == 10)
                barra += "█";
            else if (i == indice)
                barra += "▲";
            else
                barra += "░";
        }

        barText.text = barra;
    }

    void Evaluar()
    {
        jugando = false;

        float distancia = Mathf.Abs(posicion);

        AmigoDiversion diversion =
            FindFirstObjectByType<AmigoDiversion>();

        if (distancia < 0.3f)
        {
            resultText.text = "MATE DE CAMPEÓN";

            if (diversion != null)
            {
                diversion.AgregarDiversion(50);
                diversion.MostrarDialogo("¡Qué buen mate!");
            }
        }
        else if (distancia < 2f)
        {
            resultText.text = "BUEN CEBADOR";

            if (diversion != null)
            {
                diversion.AgregarDiversion(10);
                diversion.MostrarDialogo("Está bastante bien.");
            }
        }
        else if (distancia < 5f)
        {
            resultText.text = "MATE LAVADO";

            if (diversion != null)
            {
                diversion.AgregarDiversion(-5);
                diversion.MostrarDialogo("Cuidado con la Montañita.");
            }
        }
        else
        {
            resultText.text = "ARRUINASTE EL MATE";

            if (diversion != null)
            {
                diversion.AgregarDiversion(-10);
                diversion.MostrarDialogo("¿Es una Sopa o un Mate?");
            }
        }

        Invoke(nameof(Cerrar), 2f);
    }

    void Cerrar()
    {
        resultText.text = "PRESIONÁ ESPACIO";

        mateGame.SetActive(false);

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }
}