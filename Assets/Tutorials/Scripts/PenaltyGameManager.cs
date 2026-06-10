using TMPro;
using UnityEngine;

public class PenaltyGameManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI scoreText;

    public GameObject penaltyGame;

    private PlayerMovement playerMovement;

    private int playerGoals;
    private int cpuGoals;

    private int round;

    private bool playerShooting;
    private bool suddenDeath;

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
        playerGoals = 0;
        cpuGoals = 0;

        round = 0;

        playerShooting = true;
        suddenDeath = false;

        resultText.text = "";
        statusText.text = "PATEÁ";
        roundText.text = "RONDA 1/6";
        scoreText.text = "VOS 0 - 0 RIVAL";
    }

    public void Shoot(int zone)
    {
        PenaltyVideoManager video =
            FindFirstObjectByType<PenaltyVideoManager>();

        if (video != null)
        {
            video.ReproducirVideo();
        }

        int cpuChoice = Random.Range(1, 6);

        bool goal;

        if (playerShooting)
        {
            goal = zone != cpuChoice;

            if (goal)
            {
                resultText.text = "GOOOL";
                playerGoals++;
            }
            else
            {
                resultText.text = "ATAJÓ EL ARQUERO";
            }
        }
        else
        {
            goal = zone != cpuChoice;

            if (goal)
            {
                resultText.text = "GOL DEL RIVAL";
                cpuGoals++;
            }
            else
            {
                resultText.text = "ATAJASTE";
            }
        }

        scoreText.text =
            "VOS " + playerGoals +
            " - " +
            cpuGoals + " RIVAL";

        round++;

        if (!suddenDeath && round >= 6)
        {
            if (playerGoals == cpuGoals)
            {
                suddenDeath = true;

                roundText.text = "MUERTE SÚBITA";
                statusText.text = "PATEÁ";

                playerShooting = true;

                return;
            }

            FinishGame();
            return;
        }

        if (suddenDeath)
        {
            if (!playerShooting)
            {
                if (playerGoals != cpuGoals)
                {
                    FinishGame();
                    return;
                }
            }
        }

        playerShooting = !playerShooting;

        if (!suddenDeath)
        {
            roundText.text = "RONDA " + (round + 1) + "/6";
        }

        if (playerShooting)
        {
            statusText.text = "PATEÁ";
        }
        else
        {
            statusText.text = "ATAJÁ";
        }
    }

    void FinishGame()
    {
        roundText.text = "PARTIDO TERMINADO";

        AmigoDiversion diversion =
            FindFirstObjectByType<AmigoDiversion>();

        if (playerGoals > cpuGoals)
        {
            resultText.text = "GANASTE";

            if (diversion != null)
            {
                diversion.AgregarDiversion(10);
                diversion.MostrarDialogo("Casi te gano...");
            }
        }
        else
        {
            resultText.text = "PERDISTE";

            if (diversion != null)
            {
                diversion.AgregarDiversion(20);
                diversion.MostrarDialogo("¡JAJA TE GANÉ!");
            }
        }

        statusText.text = "";

        Invoke(nameof(ReturnToLiving), 3f);
    }

    void ReturnToLiving()
    {
        JugadorMover jugador = FindFirstObjectByType<JugadorMover>();

        if (jugador != null)
        {
            jugador.DetenerMovimiento();
        }

        AmigoMover amigo = FindFirstObjectByType<AmigoMover>();

        if (amigo != null)
        {
            amigo.IrALaMesa();
        }

        AmigoDiversion diversion =
            FindFirstObjectByType<AmigoDiversion>();

        if (diversion != null)
        {
            diversion.pausado = false;
        }

        penaltyGame.SetActive(false);

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }
}