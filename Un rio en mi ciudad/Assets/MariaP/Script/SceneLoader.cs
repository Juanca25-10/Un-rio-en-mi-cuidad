using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad; // Nombre de la escena a cargar
    public float fadeDuration = 1f; // Duración del fade

    [Header("Fade UI")]
    public CanvasGroup fadeGroup; // El CanvasGroup que controla el fade

    private void Start()
    {
        if (fadeGroup != null)
        {
            fadeGroup.gameObject.SetActive(true);

            // Arranca completamente opaco
            fadeGroup.alpha = 1f;
            fadeGroup.blocksRaycasts = true;
            fadeGroup.interactable = true;

            Debug.Log("Iniciando FadeIn");
            StartCoroutine(FadeIn());
        }
    }

    // Llamar a esta función desde un botón o evento
    public void LoadScene()
    {
        StartCoroutine(FadeOutAndLoad());
    }

    private IEnumerator FadeIn()
    {
        float t = fadeDuration;

        while (t > 0)
        {
            t -= Time.unscaledDeltaTime;
            fadeGroup.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }

        fadeGroup.alpha = 0f;
        fadeGroup.blocksRaycasts = false;
        fadeGroup.interactable = false;

        Debug.Log("FadeIn completado");
    }

    private IEnumerator FadeOutAndLoad()
    {
        float t = 0f;

        fadeGroup.blocksRaycasts = true;
        fadeGroup.interactable = true;

        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            fadeGroup.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }

        fadeGroup.alpha = 1f;

        SceneManager.LoadScene(sceneToLoad);
    }

    // Para resetear el fade desde otras escenas (opcional)
    public void ResetFade()
    {
        if (fadeGroup != null)
        {
            fadeGroup.alpha = 1f;
            fadeGroup.blocksRaycasts = true;
            fadeGroup.interactable = true;
            StartCoroutine(FadeIn());
        }
    }
}