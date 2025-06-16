using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculos : MonoBehaviour
{
    public static obstaculos instancia;
    public GameObject caja;
    public GameObject barril;
    public GameObject columna;
    public GameObject escombros;
    public GameObject esqueleto;

    Transform nuevoObstaculo;

    private void Awake()
    {
        instancia = this;
    }

    public void spawnearObstaculo()
    {
        int obstaculoTipo = Random.Range(0, 5);
        int carrilX = Random.Range(-1, 2);

        float posY = 0f;

        if (obstaculoTipo == 0)
        {
            nuevoObstaculo = Instantiate(caja.transform);
            //nuevoObstaculo.position = new Vector3(0f, 0f, generadorObstaculos.instanciaControlador.puntoDeSpawn);
        }
        else if (obstaculoTipo == 1)
        {
            nuevoObstaculo = Instantiate(barril.transform);
            posY = +0.5f;
            //nuevoObstaculo.position = new Vector3(0f, 0f, generadorObstaculos.instanciaControlador.puntoDeSpawn);
        }
        else if(obstaculoTipo == 2) 
        {
            nuevoObstaculo = Instantiate(columna.transform);
            carrilX = 0;
            posY = -1;
            //nuevoObstaculo.position = new Vector3(0f, -1f, generadorObstaculos.instanciaControlador.puntoDeSpawn);
        }
        else if (obstaculoTipo == 3)
        {
            nuevoObstaculo = Instantiate(escombros.transform);
            carrilX = 0;
        } else
        {
            nuevoObstaculo = Instantiate(esqueleto.transform);
            posY = -1;
        }

        nuevoObstaculo.position = new Vector3(carrilX, posY, generadorObstaculos.instanciaControlador.puntoDeSpawn);


        movEscenario.instancia.obstaculosLista.Add(nuevoObstaculo);

        generadorObstaculos.instanciaControlador.spawneando = false;
    }
}
