using UnityEngine;
using UnityEngine.EventSystems;

public class DragArmadoFinal : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    private float ultimaPosicionY;
    private int direccionAnterior = 0;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ultimaPosicionY = rectTransform.position.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition +=
            new Vector2(
                0,
                eventData.delta.y / canvas.scaleFactor);

        float diferencia =
            rectTransform.position.y -
            ultimaPosicionY;

        int direccionActual = 0;

        if (diferencia > 2f)
            direccionActual = 1;

        if (diferencia < -2f)
            direccionActual = -1;

        if (direccionActual != 0 &&
            direccionActual != direccionAnterior)
        {
            MinijuegoManager.Instance.SumarAcomodado(5);

            direccionAnterior = direccionActual;
        }

        ultimaPosicionY = rectTransform.position.y;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}