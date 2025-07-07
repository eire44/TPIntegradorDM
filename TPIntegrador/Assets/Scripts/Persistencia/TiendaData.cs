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
    public bool iman = false;
    public bool vidaExtra = false;
    public bool escudo = false;


    public TiendaData(int CantidadMonedas, int PrecioIman, int PrecioVidaExtra, int PrecioEscudo, bool Iman, bool VidaExtra, bool Escudo)
    {
        cantidadMonedas = CantidadMonedas;
        precioIman = PrecioIman;
        precioVidaExtra = PrecioVidaExtra;
        precioEscudo = PrecioEscudo;
        iman = Iman;
        vidaExtra = VidaExtra;
        escudo = Escudo;
    }
}
