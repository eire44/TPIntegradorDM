using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorObstaculos : MonoBehaviour
{
    public static generadorObstaculos instanciaControlador;

    public bool spawneando = false;
    public int generador;
    [HideInInspector]  public float puntoDeSpawn = 120f;
    [HideInInspector] public float puntoNuevoSpawn = 120f;


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

        generador = Random.Range(0, 100);
        Debug.Log(generador);

        if (generador >= 0 && generador < 30)
        {
            obstaculos.instancia.spawnearObstaculo();
        }
        else if (generador >= 30 && generador < 60)
        {
            monedas.instancia.spawnearObstaculo();
        }
        else if (generador >= 60 && generador < 70)
        {
            caminoDinamico.instancia.trampaSpawn = true;
        }
        else if (generador >= 70 && generador < 85)
        {
            flechas.instancia.spawnearFlechas();
        }
        else if (generador >= 85 && generador < 100)
        {
            spawnearPUs.instancia.spawnearObstaculo();
        }
    }
}
