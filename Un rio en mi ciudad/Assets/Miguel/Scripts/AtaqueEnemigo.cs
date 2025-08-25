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

