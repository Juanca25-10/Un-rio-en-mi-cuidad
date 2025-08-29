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

    void Start()
    {
        changeDirTimer = Random.Range(2f, 5f);
    }

    void Update()
    {
        
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        
        if (transform.position.x >= maxX)
        {
            direction = -1;
        }
        else if (transform.position.x <= minX)
        {
            direction = 1;
        }

        
        changeDirTimer -= Time.deltaTime;
        if (changeDirTimer <= 0f)
        {
            direction = Random.Range(0, 2) == 0 ? -1 : 1;
            changeDirTimer = Random.Range(2f, 5f);
        }

        
        if (speed < maxSpeed)
        {
            speed += speedIncreaseRate * Time.deltaTime;
        }
    }
}

