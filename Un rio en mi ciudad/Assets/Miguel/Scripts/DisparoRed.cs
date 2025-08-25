using UnityEngine;

public class DisparoRed : MonoBehaviour
{
    public GameObject redPrefab;
    public float redSpeed = 10f; 
    public float fireRate = 0.5f; 
    public float speedIncrease = 0.5f; 
    public float maxSpeed = 17f;      

    private Movimiento_personaje movimientoJugador;
    private bool canShoot = true;

    void Start()
    {
        movimientoJugador = GetComponent<Movimiento_personaje>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && canShoot)
        {
            Disparar();
        }
    }

    void Disparar()
    {
        canShoot = false;

        GameObject red = Instantiate(redPrefab, movimientoJugador.firePoint.position, Quaternion.identity);
        Rigidbody2D rb = red.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(movimientoJugador.GetFacingDirection() * redSpeed, 0f);

       
        if (redSpeed < maxSpeed)
        {
            redSpeed += speedIncrease;
            redSpeed = Mathf.Min(redSpeed, maxSpeed); 
        }

        Invoke(nameof(ResetShoot), fireRate);
    }

    void ResetShoot()
    {
        canShoot = true;
    }
}
