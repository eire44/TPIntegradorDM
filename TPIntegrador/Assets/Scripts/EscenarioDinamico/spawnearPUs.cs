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

        int intentos = 0;
        int maxIntentos = 20;
        float posZ = generadorObstaculos.instanciaControlador.puntoDeSpawn;
        while (generadorObstaculos.instanciaControlador.verificarPosicion(posZ) && intentos < maxIntentos)
        {
            posZ += 4;
            Debug.Log("CAMBIO EN X DE " + nuevoPU.name);
            intentos++;
        }


        nuevoPU.position = new Vector3(carrilX, posY, posZ);

        movEscenario.instancia.obstaculosLista.Add(nuevoPU);
        
        generadorObstaculos.instanciaControlador.spawneando = false;
    }
}
