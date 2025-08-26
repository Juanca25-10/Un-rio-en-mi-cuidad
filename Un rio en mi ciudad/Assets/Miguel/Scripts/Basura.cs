using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoBasura { Botella, Lata, Bolsa }

public class Basura : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocidad;

    public float inclinacionMaxima = 1.5f;

    // Nuevo: tipo de basura y puntos
    public TipoBasura tipo;
    public int puntos;

    public void Init(float velocidadInicial)
    {
        rb = GetComponent<Rigidbody2D>();
        velocidad = velocidadInicial;

        float inclinacion = Random.Range(-inclinacionMaxima, inclinacionMaxima);
        Vector2 direccion = new Vector2(inclinacion, -1f).normalized;

        rb.velocity = direccion * velocidad;

        PhysicsMaterial2D bounceMat = new PhysicsMaterial2D();
        bounceMat.bounciness = 1f;
        bounceMat.friction = 0f;
        rb.sharedMaterial = bounceMat;

        // Asignar puntos por tipo (si no lo pusiste manual en el Inspector)
        if (puntos == 0) // para que no sobreescriba si ya definiste en el editor
        {
            switch (tipo)
            {
                case TipoBasura.Botella: puntos = 10; break;
                case TipoBasura.Lata: puntos = 15; break;
                case TipoBasura.Bolsa: puntos = 20; break;
            }
        }
    }
}

