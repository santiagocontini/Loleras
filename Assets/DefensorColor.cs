using UnityEngine;

public class DefensorColor : MonoBehaviour
{
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        Color[] colores =
        {
            Color.red,
            Color.blue,
            Color.green,
            Color.yellow,
            Color.magenta,
            Color.cyan,
            Color.white
        };

        rend.material.color =
            colores[Random.Range(0, colores.Length)];
    }
}