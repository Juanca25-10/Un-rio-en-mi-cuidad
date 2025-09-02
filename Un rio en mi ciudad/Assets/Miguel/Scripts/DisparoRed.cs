using UnityEngine;

public class DisparoRed : MonoBehaviour
{
    public GameObject redPrefab;
    public float redSpeed = 10f;
    public float fireRate = 0.5f;
    public float speedIncrease = 0.5f;
    public float maxSpeed = 17f;

    private Movimiento_personaje movimientoJugador;
    private Animator animator;
    private bool canShoot = true;

    void Start()
    {
        movimientoJugador = GetComponent<Movimiento_personaje>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && canShoot)
        {
            
            animator.SetTrigger("Disparar");
            canShoot = false;
            Invoke(nameof(ResetShoot), fireRate);
        }
    }

    public void LanzarRed()
    {
        GameObject red = Instantiate(redPrefab, movimientoJugador.firePoint.position, Quaternion.identity);
        Rigidbody2D rb = red.GetComponent<Rigidbody2D>();

        // Dirección del jugador (-1 = izquierda, 1 = derecha)
        int direccion = movimientoJugador.GetFacingDirection();

        // Aplicamos velocidad
        rb.velocity = new Vector2(direccion * redSpeed, 0f);

        // Reflejamos el sprite si va a la izquierda
        SpriteRenderer sr = red.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.flipX = (direccion < 0);
        }

        // Aumentamos velocidad progresivamente
        if (redSpeed < maxSpeed)
        {
            redSpeed += speedIncrease;
            redSpeed = Mathf.Min(redSpeed, maxSpeed);
        }
    }

    void ResetShoot()
    {
        canShoot = true;
    }
}
