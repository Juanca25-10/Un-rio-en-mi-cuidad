using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum EstadoRio
{
    Sucio,
    Mejorando,
    Limpio
}

public class GameControllerNivel1 : MonoBehaviour
{
    public static GameControllerNivel1 Instance { get; private set; }

    [Header("Puntaje y Estado del Río")]
    private int puntajeNivel = 0;
    private bool nivelCompletado = false;
    public TextMeshProUGUI puntajeN1;
    public EstadoRio estadoActual = EstadoRio.Sucio;
    public int puntosParaMejorar = 300;
    public int puntosParaLimpiar = 600;

    [Header("Sistema de Vidas")]
    public List<GameObject> corazones; // arrastra aquí los 6 corazones en el inspector
    private int vidasRestantes;

    public MoviemientoAgua aguaController;

    void Start()
    {
        puntajeN1.text = "Puntaje: " + puntajeNivel.ToString();

        // Inicia con todas las vidas
        vidasRestantes = corazones.Count;
    }

 
    public void AgregarPuntos(int puntos)
    {
        puntajeNivel += puntos;
        puntajeN1.text = "Puntaje: " + puntajeNivel.ToString();
        Debug.Log("Puntaje actual del nivel: " + puntajeNivel);

        RevisarEstadoDelRio();
    }

    private void RevisarEstadoDelRio()
    {
        Debug.Log("Revisando Estado");

        if (puntajeNivel >= puntosParaLimpiar && estadoActual != EstadoRio.Limpio)
        {
            estadoActual = EstadoRio.Limpio;
            Debug.Log("El río está limpio! GANASTE!");
            Win();
        }
        else if (puntajeNivel >= puntosParaMejorar && estadoActual == EstadoRio.Sucio)
        {
            estadoActual = EstadoRio.Mejorando;
            Debug.Log("El río empieza a mejorar...");
            ActivarEventoIntermedio();
        }
    }

    private void ActivarEventoIntermedio()
    {
        // Efectos visuales intermedios
    }

    private void Win()
    {
        if (!nivelCompletado)
        {
            nivelCompletado = true;

            //GameManager.Instance.GuardarResultadoNivel(1, puntajeNivel, true);
            Debug.Log("Nivel 1 completado . Puntaje final: " + puntajeNivel);

            //UIManager.Instance.MostrarPantallaVictoria(puntajeNivel);
        }
    }

    public void PerderVida()
    {
        if (vidasRestantes <= 0) return;

        vidasRestantes--;

        if (vidasRestantes >= 0 && vidasRestantes < corazones.Count)
        {
            corazones[vidasRestantes].SetActive(false);
        }

        //  Oscurecer el agua
        if (aguaController != null)
        {
            aguaController.OscurecerAgua(0.1f);
        }

        if (vidasRestantes <= 0)
        {
            FallarNivel();
        }
    }

    public void FallarNivel()
    {
        Debug.Log("Nivel 1 fallido. No se guarda puntaje.");
        Time.timeScale = 0f; // Detiene el juego
        // Aquí puedes lanzar un menú de derrota

        GameOverManager goManager = FindObjectOfType<GameOverManager>();
        if (goManager != null)
        {
            goManager.MostrarGameOver();
        }
    }
}
