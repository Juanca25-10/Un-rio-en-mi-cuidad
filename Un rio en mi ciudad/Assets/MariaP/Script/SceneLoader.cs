using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad; // Nombre de la escena a cargar (lo pones en el inspector)
    public float fadeDuration = 1f; // Duración del fade

    [Header("Fade UI")]
    public Image fadeImage; // Imagen negra que cubre la pantalla

    private void Start()
    {
        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);

            // Bloquea clicks solo al inicio mientras está haciendo fade in
            fadeImage.raycastTarget = true;

            StartCoroutine(FadeIn());
        }
    }

    // Llamar a esta función desde un botón
    public void LoadScene()
    {
        StartCoroutine(FadeOutAndLoad());
    }

    private IEnumerator FadeIn()
    {
        float t = fadeDuration;
        Color c = fadeImage.color;

        while (t > 0)
        {
            t -= Time.deltaTime;
            c.a = t / fadeDuration;
            fadeImage.color = c;
            yield return null;
        }

        c.a = 0;
        fadeImage.color = c;

        // Cuando termina el fade in → deja pasar clicks
        fadeImage.raycastTarget = false;
    }

    private IEnumerator FadeOutAndLoad()
    {
        float t = 0;
        Color c = fadeImage.color;

        // Bloquea clicks durante el fade out
        fadeImage.raycastTarget = true;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = t / fadeDuration;
            fadeImage.color = c;
            yield return null;
        }

        c.a = 1;
        fadeImage.color = c;

        // Cambiar de escena cuando ya está negro
        SceneManager.LoadScene(sceneToLoad);
    }
}