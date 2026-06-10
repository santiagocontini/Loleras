using UnityEngine;

public class DefensorAvanza : MonoBehaviour
{
    public float velocidad = 18f;

    void Update()
    {
        transform.Translate(
            Vector3.back *
            velocidad *
            Time.deltaTime,
            Space.World);

        if (transform.position.z < -20f)
        {
            Destroy(gameObject);
        }
    }
}