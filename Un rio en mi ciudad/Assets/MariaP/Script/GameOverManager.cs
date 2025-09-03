using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject gameOverPanel;
    public GameObject panelWin;

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); 
    }

    public void MostrarGameOver()
    {
        Time.timeScale = 0f; // Pausar el juego
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void MostrarPanelWin()
    {
        Time.timeScale = 0f; // Pausar el juego
        if (panelWin != null)
            panelWin.SetActive(true);
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; // reactivar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }

    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
