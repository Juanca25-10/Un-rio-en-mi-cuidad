using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocidad;

<<<<<<< Updated upstream
    public float inclinacionMaxima = 1.5f;  
=======
    public float inclinacionMaxima = 1.5f;

    // Escalado progresivo
    public float escalaInicial = 0.3f; // más pequeño al inicio
    public float escalaMaxima = 1.2f;  // tamaño máximo cuando llega abajo
    private float yInicial;
    private float yFinal = -4f; // ajusta según la posición más baja que pueda alcanzar

    // Rotación
    public float rotacionMax = 90f;   // velocidad máxima de giro en grados/seg
    private float rotacionVel;        // la velocidad aleatoria de este objeto

    // Nuevo: tipo de basura y puntos
    public TipoBasura tipo;
    public int puntos;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
=======

        // Guardar la posición inicial en Y
        yInicial = transform.position.y;

        // Escala inicial pequeña
        transform.localScale = Vector3.one * escalaInicial;

        // Velocidad de rotación aleatoria
        rotacionVel = Random.Range(-rotacionMax, rotacionMax);

        // Asignar puntos por tipo (si no lo pusiste manual en el Inspector)
        if (puntos == 0)
        {
            switch (tipo)
            {
                case TipoBasura.Botella: puntos = 10; break;
                case TipoBasura.Lata: puntos = 15; break;
                case TipoBasura.Bolsa: puntos = 20; break;
            }
        }
>>>>>>> Stashed changes
    }

    void Update()
    {
        // Calcular cuánto ha bajado la basura en % del trayecto
        float t = Mathf.InverseLerp(yInicial, yFinal, transform.position.y);

        // Interpolar entre escalaInicial y escalaMaxima
        float escala = Mathf.Lerp(escalaInicial, escalaMaxima, t);
        transform.localScale = Vector3.one * escala;

        // Aplicar rotación progresiva
        transform.Rotate(Vector3.forward, rotacionVel * Time.deltaTime);
    }
}



