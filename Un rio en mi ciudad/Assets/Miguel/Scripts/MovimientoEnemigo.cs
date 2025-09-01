using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float speed = 2f;
    public float minX = -5f;
    public float maxX = 5f;
    private int direction = 1;

    private float changeDirTimer;
    public float speedIncreaseRate = 0.1f;
    public float maxSpeed = 10f;

    GameControllerNivel1 gameC1;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        changeDirTimer = Random.Range(2f, 5f);
        gameC1 = FindObjectOfType<GameControllerNivel1>();

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (gameC1.estadoActual == EstadoRio.Limpio) return;

        // Movimiento horizontal
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Animación: si se mueve, activa Run
        if (animator != null)
            animator.SetFloat("Speed", Mathf.Abs(speed));

        // Flip del sprite según dirección
        if (spriteRenderer != null)
        {
            if (direction > 0)
                spriteRenderer.flipX = false;
            else if (direction < 0)
                spriteRenderer.flipX = true;
        }

        // Cambiar dirección en los bordes
        if (transform.position.x >= maxX)
            direction = -1;
        else if (transform.position.x <= minX)
            direction = 1;

        // Cambio de dirección aleatorio por tiempo
        changeDirTimer -= Time.deltaTime;
        if (changeDirTimer <= 0f)
        {
            direction = Random.Range(0, 2) == 0 ? -1 : 1;
            changeDirTimer = Random.Range(2f, 5f);
        }

        // Aumentar velocidad progresiva
        if (speed < maxSpeed)
            speed += speedIncreaseRate * Time.deltaTime;
    }
}

