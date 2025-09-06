using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoviemientoAgua : MonoBehaviour
{
    public float amplitud = 0.1f; // qué tanto sube y baja
    public float velocidad = 2f;  // qué tan rápido lo hace
    private Tilemap tilemap;
    private Color colorInicial;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
        tilemap = GetComponent<Tilemap>();
        colorInicial = tilemap.color; // guardamos el color original del agua
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * velocidad) * amplitud;
        transform.position = posicionInicial + new Vector3(0, offsetY, 0);
    }


    public void OscurecerAgua(float cantidadOscurecer = 0.1f)
    {
        Color nuevoColor = tilemap.color - new Color(cantidadOscurecer, cantidadOscurecer, cantidadOscurecer, 0f);
        nuevoColor.r = Mathf.Clamp01(nuevoColor.r);
        nuevoColor.g = Mathf.Clamp01(nuevoColor.g);
        nuevoColor.b = Mathf.Clamp01(nuevoColor.b);

        tilemap.color = nuevoColor;
    }
}
