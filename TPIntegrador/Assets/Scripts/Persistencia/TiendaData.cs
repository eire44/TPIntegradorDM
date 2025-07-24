using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TiendaData
{
    public int cantidadMonedas;
    public int precioIman = 15;
    public int precioVidaExtra = 30;
    public int precioEscudo = 25;
    public int precioAntorcha = 10;
    public int precioCasco = 10;
    public bool iman = false;
    public bool vidaExtra = false;
    public bool escudo = false;
    public bool antorcha = false;
    public bool casco = false;

    public TiendaData(int CantidadMonedas, int PrecioIman, int PrecioVidaExtra, int PrecioEscudo, int PrecioAntorcha, int PrecioCasco, bool Iman, bool VidaExtra, bool Escudo, bool Antorcha, bool Casco)
    {
        cantidadMonedas = CantidadMonedas;
        precioIman = PrecioIman;
        precioVidaExtra = PrecioVidaExtra;
        precioEscudo = PrecioEscudo;
        precioAntorcha = PrecioAntorcha;
        precioCasco = PrecioCasco;
        iman = Iman;
        vidaExtra = VidaExtra;
        escudo = Escudo;
        antorcha = Antorcha;
        casco = Casco;
    }
}
