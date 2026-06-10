using UnityEngine;

public class LlaveManager : MonoBehaviour
{
    public static int esconditeLlave;
    public static bool tieneLlave = false;

    void Awake()
    {
        esconditeLlave = Random.Range(0, 5);
    }
}