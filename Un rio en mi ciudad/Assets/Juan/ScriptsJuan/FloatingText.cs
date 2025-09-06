using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float fadeSpeed = 2f;
    private TextMeshProUGUI text;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void SetText(string value)
    {
        text.text = value;
        canvasGroup.alpha = 1f; // reiniciar visibilidad
    }

    void Update()
    {
        // Mover hacia arriba en UI
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Desvanecer
        canvasGroup.alpha -= fadeSpeed * Time.deltaTime;

        if (canvasGroup.alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
