using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecordData
{
    public float distanciaMaxima;
    public int maxMonedas;
    public int partidasJugadas;
    public float promedioDistancia;
    public float distanciaTotal;

    public RecordData(float distancia, int maxMonedas, int partidasJugadas, float promedioDistancia, float distanciaTotal)
    {
        distanciaMaxima = distancia;
        this.maxMonedas = maxMonedas;
        this.partidasJugadas = partidasJugadas;
        this.promedioDistancia = promedioDistancia;
        this.distanciaTotal = distanciaTotal;
    }
}
