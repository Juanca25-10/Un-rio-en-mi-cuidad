using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash")) 
        {
         
            Destroy(collision.gameObject);

           
            Destroy(gameObject);
        }
    }
}
