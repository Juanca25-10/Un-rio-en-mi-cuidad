using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public GameObject[] trashPrefabs;
    public float spawnInterval = 1f;
    private float timer = 0f;

    public float velocidadInicial = 2f;  
    public float incrementoVelocidad = 0.3f; 
    private float velocidadActual;

    void Start()
    {
        velocidadActual = velocidadInicial;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            StartCoroutine(AttackCoroutine());
            timer = spawnInterval;
            velocidadActual += incrementoVelocidad;
        }
    }

    IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        // detener movimiento
        if (movimiento != null) movimiento.enabled = false;

        // activar animación de ataque
        if (animator != null) animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.5f); // espera la duración del ataque

        // lanzar basura después de la animación
        ThrowTrash();

        // volver a mover
        if (movimiento != null) movimiento.enabled = true;

        isAttacking = false;
    }

    void ThrowTrash()
    {
        int index = Random.Range(0, trashPrefabs.Length);
        GameObject trash = Instantiate(trashPrefabs[index], transform.position, Quaternion.identity);

        trash.GetComponent<Basura>().Init(velocidadActual);
    }
}


