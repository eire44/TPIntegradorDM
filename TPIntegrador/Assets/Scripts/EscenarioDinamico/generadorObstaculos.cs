using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorObstaculos : MonoBehaviour
{
    public static generadorObstaculos instanciaControlador;

    public bool spawneando = false;
    public int generador;
    [HideInInspector]  public float puntoDeSpawn = 120f;


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
                if ((!spawneando) && (ultimoSpawn.transform.position.z <= (puntoDeSpawn - 40)))
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

        generador = Random.Range(0, 4);

        if ((generador == 0 || generador == 1))
        {
            obstaculos.instancia.spawnearObstaculo();
        }
        else if (generador == 2)
        {
            monedas.instancia.spawnearObstaculo();
        }
        else if (generador == 3)
        {
            caminoDinamico.instancia.trampaSpawn = true;
        }
    }
}
