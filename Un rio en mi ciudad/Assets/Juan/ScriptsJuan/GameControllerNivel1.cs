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
    private int puntajeNivel = 0;
    private bool nivelCompletado = false;

    public TextMeshProUGUI puntajeN1;
    public EstadoRio estadoActual = EstadoRio.Sucio;

    public int puntosParaMejorar = 300;
    public int puntosParaLimpiar = 600;

    public void Start()
    {
       puntajeN1.text = "Puntaje: " + puntajeNivel.ToString();
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
        // Acá podés poner efectos visuales:
        // - Cambiar el color del agua
        // - Instanciar peces o aves
        // - Mostrar mensaje narrativo
    }

    private void Win()
    {
        if (!nivelCompletado)
        {
            nivelCompletado = true;

            //GameManager.Instance.GuardarResultadoNivel(1, puntajeNivel, true);

            Debug.Log("Nivel 1 completado . Puntaje final: " + puntajeNivel);

                // Mostrar pantalla de victoria
                //UIManager.Instance.MostrarPantallaVictoria(puntajeNivel);
        }
        
    }

    public void FallarNivel()
    {
        Debug.Log("Nivel 1 fallido. No se guarda puntaje.");
    }
}
