using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerBasura : MonoBehaviour
{
    private GameObject trashNearby;
    GameControllerNivel1 gameC1;
    public GameObject floatingTextPrefab;
    public Canvas canvas;
    public AudioSource pickupSound;

    void Start()
    {
        gameC1 = FindObjectOfType<GameControllerNivel1>();
    }

    void Update()
    {
        if (trashNearby != null && Input.GetKeyDown(KeyCode.M))
        {
            Basura basura = trashNearby.GetComponent<Basura>();
            if (basura != null)
            {
                Debug.Log($"Recolectaste {basura.tipo} por {basura.puntos} puntos ✅");

                // ✅ Mandamos los puntos al GameController del nivel
                gameC1.AgregarPuntos(basura.puntos);


                if (pickupSound != null && pickupSound.clip != null)
                {
                    pickupSound.PlayOneShot(pickupSound.clip);
                }

                if (floatingTextPrefab != null && canvas != null)
                {
                    GameObject ft = Instantiate(floatingTextPrefab, canvas.transform);
                    ft.GetComponent<FloatingText>().SetText("+" + basura.puntos);

                    // Convertir posición del objeto a posición en pantalla
                    Vector3 screenPos = Camera.main.WorldToScreenPoint(trashNearby.transform.position);
                    ft.transform.position = screenPos;
                }
            }

            Destroy(trashNearby);
            trashNearby = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            trashNearby = other.gameObject;
            Debug.Log("Presiona M para recoger " + trashNearby.name);
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
