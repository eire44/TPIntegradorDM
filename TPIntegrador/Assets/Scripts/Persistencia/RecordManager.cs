using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordManager
{
    private static string filePath = Application.persistentDataPath + "/recordEstadisticas.json";
    

    public static void GuardarRecord(float nuevaDistancia, int maxMonedas)
    {
        RecordData data;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<RecordData>(json);
        }
        else
        {
            data = new RecordData(0f, 0, 0, 0f, 0f);
        }

        if (nuevaDistancia > data.distanciaMaxima)
        {
            data.distanciaMaxima = nuevaDistancia;
        }

        data.maxMonedas += maxMonedas;
        data.partidasJugadas += 1;
        data.distanciaTotal += nuevaDistancia;
        data.promedioDistancia = data.distanciaTotal / data.partidasJugadas;

        string nuevoJson = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, nuevoJson);
    }

    public static float CargarRecord()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            RecordData data = JsonUtility.FromJson<RecordData>(json);
            return data.distanciaMaxima;
        }
        else
        {
            return 0f;
        }
    }

    public static int CargarCantMonedas()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            RecordData data = JsonUtility.FromJson<RecordData>(json);
            return data.maxMonedas;
        }
        else
        {
            return 0;
        }
    }
    public static int CargarCantPartidas()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            RecordData data = JsonUtility.FromJson<RecordData>(json);
            return data.partidasJugadas;
        }
        else
        {
            return 0;
        }
    }

    public static float CargarPromedioDistancia()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            RecordData data = JsonUtility.FromJson<RecordData>(json);
            return data.promedioDistancia;
        }
        else
        {
            return 0f;
        }
    }

    public static float CargarTotalDistancia()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            RecordData data = JsonUtility.FromJson<RecordData>(json);
            return data.distanciaTotal;
        }
        else
        {
            return 0f;
        }
    }
}
