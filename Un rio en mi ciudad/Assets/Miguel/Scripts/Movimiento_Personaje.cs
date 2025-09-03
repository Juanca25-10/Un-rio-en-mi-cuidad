using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_personaje : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [Header("FirePoint para disparar la red")]
    public Transform firePoint; 

    private int facingDirection = 1; 

    private float moveX;
    private float moveY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        // Movimiento
        Vector2 move = new Vector2(moveX, moveY).normalized;
        rb.velocity = move * speed;

        // ----------------- ANIMACIÓN -----------------
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);
        animator.SetFloat("Speed", move.sqrMagnitude);

        // Guardar última dirección (para Idle)
        if (move.sqrMagnitude > 0.01f)
        {
            animator.SetFloat("LastMoveX", moveX);
            animator.SetFloat("LastMoveY", moveY);
        }
        //Debug.Log($"Speed: {move.sqrMagnitude}, MoveX: {moveX}, MoveY: {moveY}");
        // ----------------- Flip y FirePoint -----------------
        if (moveX > 0)
        {
            facingDirection = 1;
            spriteRenderer.flipX = true;
            firePoint.localPosition = new Vector3(Mathf.Abs(firePoint.localPosition.x), firePoint.localPosition.y, 0);
        }
        else if (moveX < 0)
        {
            facingDirection = -1;
            spriteRenderer.flipX = false;
            firePoint.localPosition = new Vector3(-Mathf.Abs(firePoint.localPosition.x), firePoint.localPosition.y, 0);
        }
    }

    public int GetFacingDirection()
    {
        return facingDirection;
    }
}
