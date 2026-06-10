using UnityEngine;

public class GeneradorDefensores : MonoBehaviour
{
    public GameObject defensorPrefab;

    public float tiempoEntreOleadas = 1.2f;

    private float timer;

    float[] carriles =
{
    -18f,
    -14f,
    -10f,
    -6f,
    -2f,
    2f,
    6f,
    10f,
    14f,
    18f
};

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= tiempoEntreOleadas)
        {
            timer = 0f;

            CrearOleada();
        }
    }

    void CrearOleada()
    {
       int cantidadDefensores =
    Random.Range(6, 8);

        bool[] ocupado =
    new bool[10];

        int creados = 0;

        while (creados < cantidadDefensores)
        {
            int carril =
    Random.Range(0, 10);

            if (!ocupado[carril])
            {
                ocupado[carril] = true;

                Vector3 posicion =
                    new Vector3(
                        carriles[carril],
                        1f,
                        transform.position.z);

                Instantiate(
                    defensorPrefab,
                    posicion,
                    Quaternion.identity);

                creados++;
            }
        }
    }
}