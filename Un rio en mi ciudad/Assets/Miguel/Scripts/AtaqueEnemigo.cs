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

    GameControllerNivel1 gameC1;

    void Start()
    {
        velocidadActual = velocidadInicial;
        gameC1 = FindObjectOfType<GameControllerNivel1>();
    }

    void Update()
    {
        if (gameC1.estadoActual == EstadoRio.Limpio) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            ThrowTrash();
            timer = spawnInterval;

            
            velocidadActual += incrementoVelocidad;
        }
    }

    void ThrowTrash()
    {
        int index = Random.Range(0, trashPrefabs.Length);
        GameObject trash = Instantiate(trashPrefabs[index], transform.position, Quaternion.identity);

        
        trash.GetComponent<Basura>().Init(velocidadActual);
    }
}

