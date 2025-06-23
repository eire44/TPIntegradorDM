using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnearPUs : MonoBehaviour
{
    public static spawnearPUs instancia;

    public GameObject monedasPU;
    public GameObject menosMonedasPU;
    public GameObject escudoPU;
    Transform nuevoPU;

    private void Awake()
    {
        instancia = this;
    }


    public void spawnearObstaculo()
    {
        int tipoPU = Random.Range(0, 4);
        int carrilX = Random.Range(-1, 2);
        float posY = 1f;

        if(tipoPU == 0)
        {
            nuevoPU = Instantiate(monedasPU.transform);
        } else if (tipoPU == 1 || tipoPU == 2)
        {
            nuevoPU = Instantiate(menosMonedasPU.transform);
        } else
        {
            nuevoPU = Instantiate(escudoPU.transform);
        }
        

        nuevoPU.position = new Vector3(carrilX, posY, generadorObstaculos.instanciaControlador.puntoDeSpawn);

        movEscenario.instancia.obstaculosLista.Add(nuevoPU);
        
        generadorObstaculos.instanciaControlador.spawneando = false;
    }
}
