using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorObstaculos : MonoBehaviour
{
    public static generadorObstaculos instanciaControlador;

    public bool spawneando = false;
    public int generador;
    [HideInInspector]  public float puntoDeSpawn = 120f;
    [HideInInspector] public float puntoNuevoSpawn = 25f;
    int probabilidadSpawnTrampa = 30;

    private void Awake()
    {
        instanciaControlador = this;
    }
    
    void Update()
    {
        if(movEscenario.instancia.obstaculosLista.Count > 0)
        {
            Transform ultimoSpawn = movEscenario.instancia.obstaculosLista[movEscenario.instancia.obstaculosLista.Count - 1];

            if(ultimoSpawn != null)
            {
                if ((!spawneando) && (ultimoSpawn.transform.position.z <= (puntoDeSpawn - puntoNuevoSpawn)))
                {
                    spawneando = true;
                    generarObstaculo();
                }
            } else
            {
                spawneando = true;
                generarObstaculo();
            }
            
        } else
        {
            spawneando = true;
            generarObstaculo();
        }
    }

    private void generarObstaculo()
    {
        if(dificultad.instancia.nivelDificultad >= 5)
        {
            probabilidadSpawnTrampa = 32;
        }
        generador = Random.Range(0, 100);

        if (generador >= 0 && generador < probabilidadSpawnTrampa)
        {
            obstaculos.instancia.spawnearObstaculo();
        }
        else if (generador >= probabilidadSpawnTrampa && generador < 55)
        {
            caminoDinamico.instancia.trampaSpawn = true;
        }
        else if (generador >= 55 && generador < 85)
        {
            monedas.instancia.spawnearObstaculo();
        }
        else if (generador >= 85 && generador < 95)
        {
            flechas.instancia.spawnearFlechas();
        }
        else if (generador >= 95 && generador < 100)
        {
            spawnearPUs.instancia.spawnearObstaculo();
        }
    }

    public bool verificarPosicion(float posZ)
    {
        float distanciaMinima = 15f;
        foreach (var obj in movEscenario.instancia.obstaculosLista)
        {
            if (obj == null) continue;
            if (Mathf.Abs(obj.transform.position.z - posZ) < distanciaMinima)
            {
                Debug.Log(obj.name);
                return true;
            }
        }
        return false;
    }
}
