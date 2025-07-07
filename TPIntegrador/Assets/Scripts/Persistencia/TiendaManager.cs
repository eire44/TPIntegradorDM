using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TiendaManager
{
    private static string filePath = Application.persistentDataPath + "/tienda.json";

    public static void reiniciarValores()
    {
        TiendaData data = new TiendaData(0, 15, 30, 25, false, false, false);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }
    public static void GuardarRecord(bool ganancia, int CantidadMonedas, int PrecioIman, int PrecioVidaExtra, int PrecioEscudo, bool Iman, bool VidaExtra, bool Escudo)
    {
        TiendaData data;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<TiendaData>(json);
        }
        else
        {
            data = new TiendaData(0, 15, 30, 25, false, false, false);
        }


        if (ganancia)
        {
            data.cantidadMonedas += CantidadMonedas;
        }
        else
        {
            data.cantidadMonedas -= CantidadMonedas;
        }

        data.precioIman = PrecioIman;
        data.precioVidaExtra = PrecioVidaExtra;
        data.precioEscudo = PrecioEscudo;
        data.iman = Iman;
        data.vidaExtra = VidaExtra;
        data.escudo = Escudo;

        string nuevoJson = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, nuevoJson);
    }

    public static int CargarCantMonedas()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            TiendaData data = JsonUtility.FromJson<TiendaData>(json);
            return data.cantidadMonedas;
        }
        else
        {
            return RecordManager.CargarCantMonedas();
        }
    }

    public static int CargarPrecioIman()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            TiendaData data = JsonUtility.FromJson<TiendaData>(json);
            return data.precioIman;
        }
        else
        {
            return 15;
        }
    }
    public static int CargarPrecioVidaExtra()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            TiendaData data = JsonUtility.FromJson<TiendaData>(json);
            return data.precioVidaExtra;
        }
        else
        {
            return 30;
        }
    }
    public static int CargarPrecioEscudo()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            TiendaData data = JsonUtility.FromJson<TiendaData>(json);
            return data.precioEscudo;
        }
        else
        {
            return 25;
        }
    }


    public static bool CargarIman()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            TiendaData data = JsonUtility.FromJson<TiendaData>(json);
            return data.iman;
        }
        else
        {
            return false;
        }
    }
    public static bool CargarVidaExtra()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            TiendaData data = JsonUtility.FromJson<TiendaData>(json);
            return data.vidaExtra;
        }
        else
        {
            return false;
        }
    }
    public static bool CargarEscudo()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            TiendaData data = JsonUtility.FromJson<TiendaData>(json);
            return data.escudo;
        }
        else
        {
            return false;
        }
    }
}
