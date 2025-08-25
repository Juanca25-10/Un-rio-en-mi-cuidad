using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_personaje : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [Header("FirePoint para disparar la red")]
    public Transform firePoint; 

    private int facingDirection = 1; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        rb.velocity = new Vector2(moveX, moveY).normalized * speed;


        if (moveX > 0)
        {
            facingDirection = 1;
            spriteRenderer.flipX = false;
            firePoint.localPosition = new Vector3(Mathf.Abs(firePoint.localPosition.x), firePoint.localPosition.y, 0);
        }
        else if (moveX < 0)
        {
            facingDirection = -1;
            spriteRenderer.flipX = true;
            firePoint.localPosition = new Vector3(-Mathf.Abs(firePoint.localPosition.x), firePoint.localPosition.y, 0);
        }
    }

    public int GetFacingDirection()
    {
        return facingDirection;
    }
}
