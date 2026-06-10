using UnityEngine;

public class DefensorChoque : MonoBehaviour
{
    private Transform spawnJugador;

    void Start()
    {
        GameObject spawn =
            GameObject.Find("SpawnJugador");

        if (spawn != null)
        {
            spawnJugador = spawn.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawnJugador != null)
            {
                other.transform.position =
                    spawnJugador.position;
            }
        }
    }
}