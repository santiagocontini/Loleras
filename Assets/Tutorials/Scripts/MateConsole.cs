using UnityEngine;

public class MateConsole : MonoBehaviour
{
    public GameObject mateGame;

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
            mateGame.SetActive(true);

            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }
        }
    }
}