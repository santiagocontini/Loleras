using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicManagerNuevo : MonoBehaviour
{
    public GameObject musicGame;

    public AudioSource audioSource;

    public AudioClip ca7riel;
    public AudioClip nafta;

    public TextMeshProUGUI playPauseText;

    public GameObject nowPlayingNafta;
    public GameObject nowPlayingCa7riel;

    public Image progressBar;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();

        ActualizarBoton();

        nowPlayingNafta.SetActive(false);
        nowPlayingCa7riel.SetActive(false);

        progressBar.fillAmount = 0f;
    }

    void OnEnable()
    {
        ActualizarBoton();
    }

    void Update()
    {
        if (audioSource.clip != null)
        {
            progressBar.fillAmount =
                audioSource.time / audioSource.clip.length;
        }
    }

    void ActualizarBoton()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            playPauseText.text = "⏸";
        }
        else
        {
            playPauseText.text = "▶";
        }
    }

    public void ReproducirCa7riel()
    {
        audioSource.Stop();

        audioSource.clip = ca7riel;
        audioSource.Play();

        nowPlayingNafta.SetActive(false);
        nowPlayingCa7riel.SetActive(true);

        ActualizarBoton();

        AmigoDiversion diversion =
            FindFirstObjectByType<AmigoDiversion>();

        if (diversion != null)
        {
            diversion.AgregarDiversion(20);
            diversion.MostrarDialogo("¡TEMAZO!");
        }
    }

    public void ReproducirNafta()
    {
        audioSource.Stop();

        audioSource.clip = nafta;
        audioSource.Play();

        nowPlayingNafta.SetActive(true);
        nowPlayingCa7riel.SetActive(false);

        ActualizarBoton();

        AmigoDiversion diversion =
            FindFirstObjectByType<AmigoDiversion>();

        if (diversion != null)
        {
            diversion.AgregarDiversion(5);
            diversion.MostrarDialogo("¿Otra vez NAFTA?");
        }
    }

    public void ToggleMusica()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }

        ActualizarBoton();
    }

    public void ReproduccionAleatoria()
    {
        int numero = Random.Range(0, 2);

        if (numero == 0)
        {
            ReproducirCa7riel();
        }
        else
        {
            ReproducirNafta();
        }
    }

    public void CerrarPanel()
    {
        musicGame.SetActive(false);

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }
}