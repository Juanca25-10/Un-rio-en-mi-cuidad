using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgresoPorNivel
{
    //public int numNivel;
    public int puntaje;
    public bool nivelCompletado;
    public int cantidadVidasRestantes;
    public string nombreUsuario;

    public float tiempoJugado;


    public ProgresoPorNivel(string nombreP)
    {
        nombreUsuario = nombreP;
        //numNivel = numeroNivel;
        cantidadVidasRestantes = 6;
        puntaje = 0;
        nivelCompletado = false;
    }

}
