using UnityEngine;
using UnityEngine.EventSystems;

public class DragContenido : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    public RectTransform papelillo;

    RectTransform rectTransform;
    Canvas canvas;

    Vector2 posicionInicial;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        posicionInicial = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition +=
            eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distancia =
            Mathf.Abs(
                rectTransform.position.x -
                papelillo.position.x);

        int puntaje = 0;

        if (distancia < 3f)
    puntaje = 100;
else if (distancia < 10f)
    puntaje = 75;
else if (distancia < 25f)
    puntaje = 50;
else
    puntaje = 25;

        if (puntaje > 0)
        {
            rectTransform.position =
                papelillo.position;

            MinijuegoManager.Instance
                .CompletarContenido(puntaje);
        }
        else
        {
            rectTransform.anchoredPosition =
                posicionInicial;
        }
    }
}