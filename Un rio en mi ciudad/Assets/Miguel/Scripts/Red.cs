using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{

    GameControllerNivel1 gameC1;
    public GameObject floatingTextPrefab;
    public Canvas canvas;
    void Start()
    {
        //  La red se destruye sola después de 3 segundos
        Destroy(gameObject, 3f);
        gameC1 = FindObjectOfType<GameControllerNivel1>();
        canvas = FindObjectOfType<Canvas>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            Basura basura = collision.GetComponent<Basura>();
            if (basura != null)
            {
                Debug.Log($"Red atrapó {basura.tipo} por {basura.puntos} puntos");

                //  Mandamos los puntos al GameController del nivel
                gameC1.AgregarPuntos(basura.puntos);

                if (floatingTextPrefab != null && canvas != null)
                {
                    GameObject ft = Instantiate(floatingTextPrefab, canvas.transform);
                    ft.GetComponent<FloatingText>().SetText("+" + basura.puntos);

                    Vector3 screenPos = Camera.main.WorldToScreenPoint(collision.transform.position);
                    ft.transform.position = screenPos;
                }
            }

            //  Destruir basura y red
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
