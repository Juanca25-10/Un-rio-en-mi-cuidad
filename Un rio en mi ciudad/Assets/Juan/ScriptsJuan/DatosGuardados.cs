using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public class ProgresoNivelGuardado
    {
    public int numNivel;
    public int puntaje;
    public bool nivelCompletado;
    public string nombreUsuario;

    public float tiempoJugado;

    }

    [System.Serializable]
    public class DatosGuardados
    {
        public string nombreUsuario;
        public List<ProgresoNivelGuardado> progresoPorNivel = new List<ProgresoNivelGuardado>();
    }

