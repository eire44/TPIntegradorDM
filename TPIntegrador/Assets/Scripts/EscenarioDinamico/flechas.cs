using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flechas : MonoBehaviour
{
    public static flechas instancia;
    public GameObject flechasLanzador;
    GameObject nuevoLanzador;

    private void Awake()
    {
        instancia = this;
    }
    
    public void spawnearFlechas()
    {
        float arribaOabajo = 3.5f;
        int posY = Random.Range(0, 2);
        if (posY == 0)
        {
            arribaOabajo = 3.5f;
        }
        else
        {
            arribaOabajo = 1.4f;
        }
        int intentos = 0;
        int maxIntentos = 20;
        float posZ = generadorObstaculos.instanciaControlador.puntoDeSpawn;
        while (generadorObstaculos.instanciaControlador.verificarPosicion(posZ) && intentos < maxIntentos)
        {
            posZ += 4;
            Debug.Log("CAMBIO EN X DE " + flechasLanzador.name);
            intentos++;
        }


        nuevoLanzador = Instantiate(flechasLanzador);
        nuevoLanzador.transform.position = new Vector3(4.3f, arribaOabajo, posZ);
        movEscenario.instancia.obstaculosLista.Add(nuevoLanzador.transform);

        generadorObstaculos.instanciaControlador.spawneando = false;
    }
}
