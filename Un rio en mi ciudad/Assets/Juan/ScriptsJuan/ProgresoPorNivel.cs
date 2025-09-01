using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgresoPorNivel
{
    public int numNivel;
    public int puntaje;
    public bool nivelCompletado;
    public string nombreUsuario;

    public float tiempoJugado;


    public ProgresoPorNivel(int numeroNivel, string nombreP)
    {
        nombreUsuario = nombreP;
        numNivel = numeroNivel;
        puntaje = 0;
        nivelCompletado = false;
    }

}
