using UnityEngine;

public class JugadorMover : MonoBehaviour
{
    public Transform destino;
    public float velocidad = 2f;

    private bool caminar = false;

    public bool LlegoADestino
    {
        get { return !caminar; }
    }

    void Update()
    {
        if (caminar)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destino.position,
                velocidad * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, destino.position) < 0.1f)
            {
                caminar = false;
            }
        }
    }

    public void IrAlSofa()
    {
        caminar = true;
    }

    public void DetenerMovimiento()
    {
        caminar = false;
    }
}