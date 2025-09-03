using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarBasura : MonoBehaviour
{
    GameControllerNivel1 gameC;
    public AudioSource squashSound;


    void Start()
    {
        gameC = FindObjectOfType<GameControllerNivel1>();


        if( squashSound == null)
        {
            squashSound = GetComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            Debug.Log("Basura detectada, perdiendo vida...");
            gameC.PerderVida();

            if (squashSound != null && squashSound.clip != null)
            {
                squashSound.PlayOneShot(squashSound.clip);
            }

            // opcional: destruir la basura al tocar el borde
            Destroy(other.gameObject);
        }
    }
}
