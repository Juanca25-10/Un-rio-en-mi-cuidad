using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]

public class EntradaRanking
{
    public string nombreUsuario;
    public int puntaje;
    public int cantidadVidasRestantes;
    public float tiempoJugado;
}
//public class ProgresoNivelGuardado
//{
////public int numNivel;
//public int puntaje;
//public bool nivelCompletado;
//public int cantidadVidasRestantes;
//public string nombreUsuario;

//public float tiempoJugado;

//}

[System.Serializable]
public class DatosGuardados
{
    public List<EntradaRanking> ranking = new List<EntradaRanking>();
}

//[System.Serializable]
//    public class DatosGuardados
//    {
//        public string nombreUsuario;
//        public List<ProgresoNivelGuardado> progresoPorNivel = new List<ProgresoNivelGuardado>();
//    }

