using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NarrativeManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject[] panels; // arrastra todos los paneles en orden
    private int currentIndex = 0;

    [Header("Buttons")]
    public Button nextButton;   // botón Siguiente
    public Button backButton;   // botón Atrás
    public Button playButton;   // botón Play (solo se muestra en el último panel)

    [Header("Scene Settings")]
    public string mainSceneName = "EscenaPrincipal"; // nombre de la escena del nivel

    void Start()
    {
        // Desactivar todos los paneles
        foreach (GameObject p in panels)
            p.SetActive(false);

        // Activar el primero
        if (panels.Length > 0)
            panels[0].SetActive(true);

        UpdateButtons();
    }

    public void NextPanel()
    {
        // Apagar panel actual
        panels[currentIndex].SetActive(false);
        currentIndex++;

        // Activar el siguiente panel
        if (currentIndex < panels.Length)
            panels[currentIndex].SetActive(true);

        UpdateButtons();
    }

    public void PreviousPanel()
    {
        // Apagar panel actual
        panels[currentIndex].SetActive(false);
        currentIndex--;

        // Activar el panel anterior
        if (currentIndex >= 0)
            panels[currentIndex].SetActive(true);

        UpdateButtons();
    }

    private void UpdateButtons()
    {
        // El botón Atrás solo aparece desde el segundo panel y no en el último
        if (backButton != null)
            backButton.gameObject.SetActive(currentIndex > 0 && currentIndex < panels.Length - 1);

        // El botón Next aparece en todos menos en el último
        if (nextButton != null)
            nextButton.gameObject.SetActive(currentIndex < panels.Length - 1);

        // El botón Play solo aparece en el último panel
        if (playButton != null)
            playButton.gameObject.SetActive(currentIndex == panels.Length - 1);
    }

    //  Esta función se asigna al botón Play
    public void PlayGame()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}