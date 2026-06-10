using UnityEngine;

public class GoalAvanza : MonoBehaviour
{
    public float velocidad = 8f;

    public float puntoPenal = 10f;

    bool terminado = false;

    void Update()
    {
        if (terminado)
            return;

        transform.Translate(
            Vector3.back *
            velocidad *
            Time.deltaTime,
            Space.World);

        if (transform.position.z <= puntoPenal)
        {
            terminado = true;

            ActivarPenal();
        }
    }

    void ActivarPenal()
    {
        Debug.Log("INICIAR PENALES");
    }
}