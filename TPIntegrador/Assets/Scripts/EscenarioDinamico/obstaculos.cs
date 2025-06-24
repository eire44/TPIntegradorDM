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
    public GameObject trampaFuego;
    public GameObject techo;

    Transform nuevoObstaculo;

    private void Awake()
    {
        instancia = this;
    }

    public void spawnearObstaculo()
    {
        int obstaculoTipo = Random.Range(0, 9);
        int carrilX = Random.Range(-1, 2);

        float posY = 0f;

        if (obstaculoTipo == 0)
        {
            nuevoObstaculo = Instantiate(caja.transform);
        }
        else if (obstaculoTipo == 1)
        {
            nuevoObstaculo = Instantiate(barril.transform);
            posY = 1f;
        }
        else if(obstaculoTipo == 2) 
        {
            nuevoObstaculo = Instantiate(columna.transform);
            carrilX = 0;
            posY = -1;
        }
        else if (obstaculoTipo == 3)
        {
            nuevoObstaculo = Instantiate(escombros.transform);
            carrilX = 0;
        }
        else if (obstaculoTipo == 4)
        {
            nuevoObstaculo = Instantiate(techo.transform);
            posY = 3.18f;
            
        }
        else if (obstaculoTipo == 5)
        {
            nuevoObstaculo = Instantiate(trampaFuego.transform);
            posY = -0.8f;
        } else
        {
            nuevoObstaculo = Instantiate(esqueleto.transform);
            posY = -1;
        }

        int intentos = 0;
        int maxIntentos = 20;
        float posZ = generadorObstaculos.instanciaControlador.puntoDeSpawn;
        while (generadorObstaculos.instanciaControlador.verificarPosicion(posZ) && intentos < maxIntentos)
        {
            posZ += 4;
            Debug.Log("CAMBIO EN X DE " + nuevoObstaculo.name);
            intentos++;
        }

        nuevoObstaculo.position = new Vector3(carrilX, posY, posZ);


        movEscenario.instancia.obstaculosLista.Add(nuevoObstaculo);

        generadorObstaculos.instanciaControlador.spawneando = false;
    }
}
