using UnityEngine;

public class AmigoMover : MonoBehaviour
{
    public Transform destinoSofa;
    public Transform destinoMesa;
    public Transform destinoPuerta;

    public float velocidad = 2f;

    private Transform destinoActual;

    private bool caminar = false;

    public bool LlegoADestino
    {
        get { return !caminar; }
    }

    void Update()
    {
        if (caminar && destinoActual != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destinoActual.position,
                velocidad * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, destinoActual.position) < 0.1f)
            {
                caminar = false;
            }
        }
    }

    public void IrAlSofa()
    {
        destinoActual = destinoSofa;
        caminar = true;
    }

    public void IrALaMesa()
    {
        destinoActual = destinoMesa;
        caminar = true;
    }

    public void IrALaPuerta()
    {
        destinoActual = destinoPuerta;
        caminar = true;
    }
}