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
    bool ultimoSpawnEsTrampaPiso = false;
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

        if(dificultad.instancia.nivelDificultad >= 4)
        {
            generador = Random.Range(0, 100);
        } else
        {
            generador = Random.Range(0, 95);
        }

        if(ultimoSpawnEsTrampaPiso)
        {
            if(generador >= probabilidadSpawnTrampa && generador < 55)
            {
                generador = 0;
            }
        }
        

        if (generador >= 0 && generador < probabilidadSpawnTrampa)
        {
            obstaculos.instancia.spawnearObstaculo();
            ultimoSpawnEsTrampaPiso = false;
        }
        else if (generador >= probabilidadSpawnTrampa && generador < 55)
        {
            caminoDinamico.instancia.trampaSpawn = true;
            ultimoSpawnEsTrampaPiso = true;
        }
        else if (generador >= 55 && generador < 85)
        {
            monedas.instancia.spawnearObstaculo();
            ultimoSpawnEsTrampaPiso = false;
        }
        else if (generador >= 85 && generador < 95)
        {
            flechas.instancia.spawnearFlechas();
            ultimoSpawnEsTrampaPiso = false;
        }
        else if (generador >= 95 && generador < 100)
        {
            spawnearPUs.instancia.spawnearObstaculo();
            ultimoSpawnEsTrampaPiso = false;
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
