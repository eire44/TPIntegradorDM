using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnearPUs : MonoBehaviour
{
    public static spawnearPUs instancia;

    public GameObject monedasPU;
    public GameObject menosMonedasPU;
    Transform nuevoPU;

    private void Awake()
    {
        instancia = this;
    }


    public void spawnearObstaculo()
    {
        int tipoPU = Random.Range(0, 2);
        int carrilX = Random.Range(-1, 2);
        float posY = 1f;

        if(tipoPU == 0)
        {
            nuevoPU = Instantiate(monedasPU.transform);
        } else
        {
            nuevoPU = Instantiate(menosMonedasPU.transform);
        }
        
        //nuevoObstaculo.position = new Vector3(0f, 0f, generadorObstaculos.instanciaControlador.puntoDeSpawn);

        nuevoPU.position = new Vector3(carrilX, posY, generadorObstaculos.instanciaControlador.puntoDeSpawn);

        movEscenario.instancia.obstaculosLista.Add(nuevoPU);
        
        generadorObstaculos.instanciaControlador.spawneando = false;
    }
}
