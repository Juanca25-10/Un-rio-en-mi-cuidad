using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerBasura : MonoBehaviour
{
    private GameObject trashNearby; 

    void Update()
    {
       
        if (trashNearby != null && Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Recolectaste basura ✅: " + trashNearby.name);
            Destroy(trashNearby);
            trashNearby = null;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            trashNearby = other.gameObject; 
            Debug.Log("Presiona E para recoger " + trashNearby.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Trash") && other.gameObject == trashNearby)
        {
            trashNearby = null; 
            Debug.Log("Te alejaste de la basura");
        }
    }
}
