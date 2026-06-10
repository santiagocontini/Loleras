using UnityEngine;

public class PastoScroll : MonoBehaviour
{
    public float velocidad = 0.5f;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset =
            Time.time * velocidad;

        rend.material.mainTextureOffset =
            new Vector2(0, -offset);
    }
}