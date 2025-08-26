using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControllerNivel1 : MonoBehaviour
{
    public static GameControllerNivel1 Instance { get; private set; }
    private int puntajeNivel = 0;
    private bool nivelCompletado = false;

    public TextMeshProUGUI puntajeN1;

    public void Start()
    {
       puntajeN1.text = "Puntaje: " + puntajeNivel.ToString();
    }

    public void AgregarPuntos(int puntos)
    {
        puntajeNivel += puntos;
        puntajeN1.text = "Puntaje: " + puntajeNivel.ToString();
        Debug.Log("Puntaje actual del nivel: " + puntajeNivel);
    }

    public void CompletarNivel()
    {
        if (!nivelCompletado)
        {
            nivelCompletado = true;

            GameManager.Instance.GuardarResultadoNivel(1, puntajeNivel, true);

            Debug.Log("Nivel 1 completado . Puntaje final: " + puntajeNivel);
        }
    }

    public void FallarNivel()
    {
        Debug.Log("Nivel 1 fallido. No se guarda puntaje.");
        // Podrías marcar el nivel como no completado en GameManager si querés
    }
}
