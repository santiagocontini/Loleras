using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    public GameObject interactionText;

    public GameObject goalPanel;
    public TextMeshProUGUI goalText;

    bool jugadorCerca = false;

    void Update()
    {
        if (jugadorCerca &&
            Input.GetKeyDown(KeyCode.E))
        {
            interactionText.SetActive(false);

            goalPanel.SetActive(true);

            goalText.text = "¡¡GOOOOL!!";

            Invoke(nameof(IrACalle), 2f);
        }
    }

    void IrACalle()
    {
        SceneManager.LoadScene("calle");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;

            interactionText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;

            interactionText.SetActive(false);
        }
    }
}