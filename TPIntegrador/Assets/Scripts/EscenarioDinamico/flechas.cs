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
        float arribaOabajo = 5.6f;
        int posY = Random.Range(0, 2);
        if (posY == 0)
        {
            arribaOabajo = 5.6f;
        }
        else
        {
            arribaOabajo = 1.4f;
        }
        nuevoLanzador = Instantiate(flechasLanzador);
        Debug.Log("SPAWN");
        nuevoLanzador.transform.position = new Vector3(4.3f, arribaOabajo, generadorObstaculos.instanciaControlador.puntoDeSpawn);
        movEscenario.instancia.obstaculosLista.Add(nuevoLanzador.transform);

        generadorObstaculos.instanciaControlador.spawneando = false;
    }
}
