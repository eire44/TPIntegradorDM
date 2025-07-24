using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class monedas : MonoBehaviour
{
    public static monedas instancia;

    public GameObject monedasPrefab;
    Transform nuevaMoneda;

    private void Awake()
    {
        instancia = this;
    }


    public void spawnearObstaculo()
    {
        int carrilX = Random.Range(-1, 2);
        int cantidad = Random.Range(3, 6);
        float posY = 0f;

        int intentos = 0;
        int maxIntentos = 20;
        float posZ = generadorObstaculos.instanciaControlador.puntoDeSpawn;
        while (generadorObstaculos.instanciaControlador.verificarPosicion(posZ) && intentos < maxIntentos)
        {
            posZ += 3;
            intentos++;
        }

        for (int i = 0; i < cantidad; i++)
        {
            nuevaMoneda = Instantiate(monedasPrefab.transform);
            //nuevoObstaculo.position = new Vector3(0f, 0f, generadorObstaculos.instanciaControlador.puntoDeSpawn);

            nuevaMoneda.position = new Vector3(carrilX, posY, posZ + (i*3));

            movEscenario.instancia.obstaculosLista.Add(nuevaMoneda);
        }
        generadorObstaculos.instanciaControlador.spawneando = false;
    }
}
