using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscuridad : MonoBehaviour
{
    float tiempoSpawn = 30f;
    float tiempoOscuridad = 20f;
    float tiempoTranscurrido = 0f;
    Light luz;
    bool estaOscuro = false;

    void Start()
    {
        luz = GameObject.Find("Directional Light").GetComponent<Light>();
        tiempoTranscurrido = tiempoOscuridad;
    }

    void Update()
    {
        if (!estaOscuro)
        {
            tiempoSpawn -= Time.deltaTime;

            if (tiempoSpawn <= 0f)
            {
                tiempoSpawn = 30f;
                int probabilidad = Random.Range(0, 3);

                if (probabilidad == 0)
                {
                    Debug.Log("OSCURIDAD");
                    luz.intensity = 0.1f;
                    estaOscuro = true;
                    tiempoTranscurrido = tiempoOscuridad;
                }
            }
        }
        else
        {
            tiempoTranscurrido -= Time.deltaTime;

            if (tiempoTranscurrido <= 0f)
            {
                luz.intensity = 0.82f;
                estaOscuro = false;
                tiempoSpawn = 20f;
            }
        }
    }
}
