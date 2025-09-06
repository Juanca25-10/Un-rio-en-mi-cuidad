using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public TextMeshProUGUI rankingText;
    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    void Awake()
    {
        SceneLoader loader = FindObjectOfType<SceneLoader>();
        if (loader != null)
        {
            loader.ResetFade();
        }

        if (GameManager.Instance == null)
        {
            Debug.LogWarning("GameManager no encontrado, cargando datos manualmente...");
            DatosGuardados datos = JsonGuardado.CargarDatos();
            if (datos != null)
            {
                var top5 = datos.ranking
                    .OrderByDescending(e => e.puntaje)
                    .Take(5)
                    .ToList();

                string res = "";
                for (int i = 0; i < top5.Count; i++)
                {
                    string tiempoFormateado = top5[i].tiempoJugado.ToString("F2");
                    res += $"{i + 1}. {top5[i].nombreUsuario} - {top5[i].puntaje} puntos - Vidas: {top5[i].cantidadVidasRestantes} - Tiempo: {tiempoFormateado} seg\n";
                }

                rankingText.text = res;
            }
            else
            {
                rankingText.text = "No hay puntajes aún.";
            }

            return;
        }

        if (rankingText != null)
        {
            rankingText.text = MostrarRanking();
        }
    }

    public string MostrarRanking()
    {
        if (GameManager.Instance == null || GameManager.Instance.ranking == null)
            return "No hay puntajes aún.";

        string res = "";

        var top5 = GameManager.Instance.ranking.Take(5).ToList();

        for (int i = 0; i < top5.Count; i++)
        {
            string tiempoFormateado = top5[i].tiempoJugado.ToString("F2");
            res += $"{i + 1}. {top5[i].nombreUsuario} - {top5[i].puntaje} puntos - Vidas: {top5[i].cantidadVidasRestantes} - Tiempo: {tiempoFormateado} seg\n";
        }

        return string.IsNullOrEmpty(res) ? "No hay puntajes aún." : res;
    }

    public void SalirJuego()
    {
        // Esto cierra el juego en el build final
        Application.Quit();

        // Esto solo se ejecuta en el editor, para simular la salida
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
