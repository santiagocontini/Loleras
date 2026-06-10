using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinijuegoManager : MonoBehaviour
{
    public static MinijuegoManager Instance;

    [Header("UI")]
    public TextMeshProUGUI textoFase;
    public TextMeshProUGUI textoInstruccion;
    public Slider barraProgreso;

    [Header("Objetos")]
    public GameObject picador;
    public GameObject filtro;
    public GameObject papelillo;
    public GameObject puntoFiltro;
    public GameObject contenido;
    public GameObject armadoFinal;

    [Header("Puntajes")]
    public int puntajePicado = 0;
    public int puntajeFiltro = 0;
    public int puntajeContenido = 0;
    public int puntajeEnrollado = 0;
    public int puntajeAcomodado = 0;
    public int puntajeFinal = 0;

    private float tiempoInicioPicado;
    private float tiempoInicioEnrollado;
    private float tiempoInicioAcomodado;

    private float progresoPicado = 0;
    private int direccionAnterior = 0;

    private float progresoEnrollado = 0;
    private KeyCode ultimaTeclaEnrollado;

    private float progresoAcomodado = 0;

    void Start()
    {
        Instance = this;

        tiempoInicioPicado = Time.time;

        textoFase.text = "FASE: PICAR";

        textoInstruccion.text =
            "Mantene clic izquierdo y move el mouse de izquierda a derecha.";

        barraProgreso.value = 0;

        filtro.SetActive(false);
        papelillo.SetActive(false);
        puntoFiltro.SetActive(false);
        contenido.SetActive(false);
        armadoFinal.SetActive(false);
    }

    void Update()
    {
        if (textoFase.text == "FASE: PICAR")
        {
            ActualizarPicado();
        }
        else if (textoFase.text == "FASE: ENROLLAR")
        {
            ActualizarEnrollado();
        }
    }

    int CalcularPuntajePorTiempo(float tiempo)
{
    if (tiempo <= 3f)
        return 100;

    if (tiempo >= 12f)
        return 10;

    return Mathf.RoundToInt(
        Mathf.Lerp(100, 10, (tiempo - 3f) / 9f)
    );
}

    void ActualizarPicado()
    {
        if (Input.GetMouseButton(0))
        {
            float movimiento = Input.GetAxis("Mouse X");

            int direccionActual = 0;

            if (movimiento > 0.05f)
                direccionActual = 1;

            if (movimiento < -0.05f)
                direccionActual = -1;

            if (direccionActual != 0 &&
                direccionActual != direccionAnterior)
            {
                progresoPicado += 5;

                barraProgreso.value = progresoPicado;

                direccionAnterior = direccionActual;
            }
        }

        if (progresoPicado >= 100)
        {
            IniciarFaseFiltro();
        }
    }

    void IniciarFaseFiltro()
    {
        float tiempoPicado =
            Time.time - tiempoInicioPicado;

        puntajePicado =
            CalcularPuntajePorTiempo(tiempoPicado);

        Debug.Log("PICADO: " + puntajePicado);

        textoFase.text = "FASE: FILTRO";

        textoInstruccion.text =
            "Arrastra el filtro hasta el extremo izquierdo del papelillo.";

        picador.SetActive(false);

        filtro.SetActive(true);
        papelillo.SetActive(true);
        puntoFiltro.SetActive(true);
    }

    public void CompletarFiltro(int puntos)
    {
        puntajeFiltro = puntos;

        textoFase.text = "FASE: CONTENIDO";

        textoInstruccion.text =
            "Arrastra el contenido al centro del papelillo.";

        contenido.SetActive(true);
    }

    public void CompletarContenido(int puntos)
    {
        puntajeContenido = puntos;

        textoFase.text = "FASE: ENROLLAR";

        textoInstruccion.text =
            "Alterna las teclas A y D para enrollar.";

        barraProgreso.value = 0;
        progresoEnrollado = 0;

        tiempoInicioEnrollado = Time.time;
    }

    void ActualizarEnrollado()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ProcesarTeclaEnrollado(KeyCode.A);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ProcesarTeclaEnrollado(KeyCode.D);
        }
    }

    void ProcesarTeclaEnrollado(KeyCode tecla)
    {
        if (tecla != ultimaTeclaEnrollado)
        {
            progresoEnrollado += 10;

            barraProgreso.value = progresoEnrollado;

            ultimaTeclaEnrollado = tecla;
        }
        else
        {
            progresoEnrollado -= 5;

            if (progresoEnrollado < 0)
                progresoEnrollado = 0;

            barraProgreso.value = progresoEnrollado;
        }

        if (progresoEnrollado >= 100)
        {
            CompletarEnrollado();
        }
    }

    void CompletarEnrollado()
    {
        float tiempoEnrollado =
            Time.time - tiempoInicioEnrollado;

        puntajeEnrollado =
            CalcularPuntajePorTiempo(tiempoEnrollado);

        Debug.Log("ENROLLADO: " + puntajeEnrollado);

        textoFase.text = "FASE: ACOMODAR";

        textoInstruccion.text =
            "Arrastra el armado arriba y abajo para acomodarlo.";

        barraProgreso.value = 0;
        progresoAcomodado = 0;

        filtro.SetActive(false);
        contenido.SetActive(false);
        puntoFiltro.SetActive(false);
        papelillo.SetActive(false);

        armadoFinal.SetActive(true);

        tiempoInicioAcomodado = Time.time;
    }

    public void SumarAcomodado(float cantidad)
    {
        progresoAcomodado += cantidad;

        barraProgreso.value = progresoAcomodado;

        if (progresoAcomodado >= 100)
        {
            CompletarAcomodado();
        }
    }

    void CompletarAcomodado()
{
    Debug.Log("ENTRO A COMPLETAR ACOMODADO");

    float tiempoAcomodado =
        Time.time - tiempoInicioAcomodado;

            puntajeAcomodado =
            CalcularPuntajePorTiempo(tiempoAcomodado);

        puntajeFinal =
        (
            puntajePicado +
            puntajeFiltro +
            puntajeContenido +
            puntajeEnrollado +
            puntajeAcomodado
        ) / 5;

ResultadoArmado.ultimoPuntaje = puntajeFinal;
ResultadoArmado.mostrarResultado = true;

        Debug.Log("PICADO: " + puntajePicado);
        Debug.Log("FILTRO: " + puntajeFiltro);
        Debug.Log("CONTENIDO: " + puntajeContenido);
        Debug.Log("ENROLLADO: " + puntajeEnrollado);
        Debug.Log("ACOMODADO: " + puntajeAcomodado);
        Debug.Log("PUNTAJE FINAL: " + puntajeFinal);

        textoFase.text = "MINIJUEGO TERMINADO";

        textoInstruccion.text =
            "¡Armado terminado!";

        Invoke(nameof(CerrarMinijuego), 2f);
    }

    void CerrarMinijuego()
    {
        SceneManager.UnloadSceneAsync("MinijuegoArmado");
    }
}