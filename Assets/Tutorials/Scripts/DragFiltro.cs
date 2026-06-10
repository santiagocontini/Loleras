using UnityEngine;
using UnityEngine.EventSystems;

public class DragFiltro : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    public RectTransform puntoFiltro;

    private RectTransform rectTransform;
    private Canvas canvas;

    private Vector2 posicionInicial;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        posicionInicial = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("EMPEZO A ARRASTRAR FILTRO");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("ARRASTRANDO FILTRO");

        rectTransform.anchoredPosition +=
            eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("SOLTO FILTRO");

        float distancia =
            Vector2.Distance(
                rectTransform.position,
                puntoFiltro.position);

        Debug.Log("DISTANCIA: " + distancia);

        if (distancia < 50f)
        {
            rectTransform.position =
                puntoFiltro.position;

            int puntaje = 0;

            if (distancia < 3f)
                puntaje = 100;
            else if (distancia < 10f)
                puntaje = 75;
            else if (distancia < 25f)
                puntaje = 50;
            else
                puntaje = 25;

            Debug.Log("PUNTAJE FILTRO: " + puntaje);

            MinijuegoManager.Instance.CompletarFiltro(puntaje);
        }
        else
        {
            rectTransform.anchoredPosition =
                posicionInicial;
        }
    }
}