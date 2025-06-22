using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordManager
{
    private static string filePath = Application.persistentDataPath + "/recordDistancia.json";
    
    public static void GuardarRecord(float nuevaDistancia)
    {
        RecordData data;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<RecordData>(json);
        }
        else
        {
            data = new RecordData(0f);
        }

        if (nuevaDistancia > data.distanciaMaxima)
        {
            data.distanciaMaxima = nuevaDistancia;
        }

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
}
