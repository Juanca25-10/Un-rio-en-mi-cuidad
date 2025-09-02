using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarBasura : MonoBehaviour
{
    GameControllerNivel1 gameC;

    void Start()
    {
        gameC = FindObjectOfType<GameControllerNivel1>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            Debug.Log("Basura detectada, perdiendo vida...");
            gameC.PerderVida();

            // opcional: destruir la basura al tocar el borde
            Destroy(other.gameObject);
        }
    }
}
