using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoBasura { Botella, Lata, Bolsa }

public class Basura : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocidad;

    public float inclinacionMaxima = 1.5f;

    // Escalado progresivo
    public float escalaInicial = 0.3f;
    public float escalaMaxima = 1.2f;
    private float yInicial;
    private float yFinal = -4f;

    // Rotación
    public float rotacionMax = 90f;
    private float rotacionVel;

    // Tipo de basura y puntos
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

        // Guardar posición inicial en Y
        yInicial = transform.position.y;

        // Escala inicial
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


