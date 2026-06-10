using UnityEngine;

public class PlayConsole : MonoBehaviour
{
    public GameObject penaltyGame;

    public AmigoMover amigo;
    public JugadorMover jugador;

    private bool playerNear = false;
    private bool esperando = false;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

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
        if (playerNear && Input.GetKeyDown(KeyCode.E) && !esperando)
        {
            esperando = true;

            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            if (jugador != null)
            {
                jugador.IrAlSofa();
            }

            if (amigo != null)
            {
                amigo.IrAlSofa();
            }
        }

        if (esperando &&
            amigo != null &&
            amigo.LlegoADestino)
        {
            esperando = false;

            AmigoDiversion diversion =
                FindFirstObjectByType<AmigoDiversion>();

            if (diversion != null)
            {
                diversion.pausado = true;
            }

            penaltyGame.SetActive(true);
        }
    }
}