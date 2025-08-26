using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<ProgresoPorNivel> progresoNivel = new List<ProgresoPorNivel>();
    public string nombreUsuario = "PartidaSinNombre";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            DatosGuardados datos = JsonGuardado.CargarDatos();

            if (datos != null)
            {
                CargarProgresoDesdeJson(datos);
                Debug.Log("Progreso cargado desde JSON.");
            }
            else
            {

                //menuManager = FindObjectOfType<MenuManager>();
                //menuManager.EncenderPanelNombre();

                InicializarProgreso();
                GuardarProgresoEnJson(); // Guardamos de una vez
                Debug.Log("Progreso inicializado con nueva partida.");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InicializarProgreso()
    {
        progresoNivel.Clear();
        progresoNivel.Add(new ProgresoPorNivel(1, nombreUsuario));
        progresoNivel.Add(new ProgresoPorNivel(2, nombreUsuario));
        
    }

    public void GuardarProgresoEnJson()
    {
        DatosGuardados datos = new DatosGuardados();

        foreach (ProgresoPorNivel prog in progresoNivel)
        {
            datos.progresoPorNivel.Add(new ProgresoNivelGuardado
            {
                numNivel = prog.numNivel,
                puntaje = prog.puntaje,
                nivelCompletado = prog.nivelCompletado,
                nombreUsuario = nombreUsuario,
                tiempoJugado = prog.tiempoJugado
            });
        }

        JsonGuardado.GuardarDatos(datos);
    }


}
