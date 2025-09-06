using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<EntradaRanking> ranking = new List<EntradaRanking>();
    public string nombreUsuarioActual = "Jugador";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            DatosGuardados datos = JsonGuardado.CargarDatos();

            if (datos != null)
            {
                ranking = datos.ranking;
                Debug.Log("Ranking cargado desde JSON.");
            }
            else
            {
                ranking = new List<EntradaRanking>();
                GuardarProgresoEnJson();
                Debug.Log("Ranking inicializado.");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GuardarResultadoNivel(int puntajeFinal, bool completado, int CantVidas, float tiempo)
    {
        // No importa si ganó o no, agregamos la entrada igual (o puedes filtrar si quieres)
        EntradaRanking nuevaEntrada = new EntradaRanking
        {
            nombreUsuario = nombreUsuarioActual,
            puntaje = puntajeFinal,
            cantidadVidasRestantes = CantVidas,
            tiempoJugado = tiempo
        };

        ranking.Add(nuevaEntrada);

        // Ordenamos de mayor a menor puntaje (puedes modificar criterio)
        ranking = ranking.OrderByDescending(e => e.puntaje).ToList();

        GuardarProgresoEnJson();
    }

    public void GuardarProgresoEnJson()
    {
        DatosGuardados datos = new DatosGuardados();
        datos.ranking = ranking;
        JsonGuardado.GuardarDatos(datos);
    }

}
