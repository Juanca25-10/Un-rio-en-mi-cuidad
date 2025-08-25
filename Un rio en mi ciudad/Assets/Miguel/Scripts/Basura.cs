using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocidad;

    public float inclinacionMaxima = 1.5f;  

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
    }
}

