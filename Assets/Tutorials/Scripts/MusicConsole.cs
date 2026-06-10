using UnityEngine;

public class MusicConsole : MonoBehaviour
{
    public GameObject musicGame;

    private bool playerNear = false;

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
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            musicGame.SetActive(true);

            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }
        }
    }
}