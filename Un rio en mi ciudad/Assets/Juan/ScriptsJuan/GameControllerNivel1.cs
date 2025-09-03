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
    public int puntosParaMejorar = 100;
    public int puntosParaLimpiar = 250;

    [Header("Sistema de Vidas")]
    public List<GameObject> corazones; // arrastra aquí los 6 corazones en el inspector
    public AudioClip errorSound;
    public AudioClip gameOverSound;
    public AudioClip winSound;
    public AudioClip puntoSound;
    private int vidasRestantes;

    private AudioSource audioSource;

    public MoviemientoAgua aguaController;
    public GameOverManager goManager;

    void Start()
    {
        puntajeN1.text = "Puntaje: " + puntajeNivel.ToString();

        // Inicia con todas las vidas
        vidasRestantes = corazones.Count;

        audioSource = GetComponent<AudioSource>();
        goManager = FindObjectOfType<GameOverManager>();
    }

 
    public void AgregarPuntos(int puntos)
    {
        puntajeNivel += puntos;
        if (puntoSound != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(puntoSound);
        }
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

            if (winSound != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(winSound);
            }

            //GameManager.Instance.GuardarResultadoNivel(1, puntajeNivel, true);
            Debug.Log("Nivel 1 completado . Puntaje final: " + puntajeNivel);

            if (goManager != null)
            {
                goManager.MostrarPanelWin();
            }
        }
    }

    public void PerderVida()
    {
        if (vidasRestantes <= 0) return;

        if (errorSound != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(errorSound);
        }

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

        if (gameOverSound != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }

        Debug.Log("Nivel 1 fallido. No se guarda puntaje.");
        Time.timeScale = 0f; // Detiene el juego
        // Aquí puedes lanzar un menú de derrota

        
        if (goManager != null)
        {
            goManager.MostrarGameOver();
        }
    }

    public void BotonGuardarScoreNombre()
    {
        Debug.Log("Guardando Puntaje con Nombre");
    }
}
