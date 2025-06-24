using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dificultad : MonoBehaviour
{
    public static dificultad instancia;
    public int velocidadAc = 10;
    public int nivelDificultad = 1;
    public float velocidadBalaJ = 25f;
    public int vidasE = 3;

    private void Awake()
    {
        instancia = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        Physics.gravity = new Vector3(0, -9.8f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (nivelDificultad == 2)
        {
            movEscenario.instancia.velocidad = 20;
            caminoDinamico.instancia.velocidad = 20;
            
        }
        else if (nivelDificultad == 3)
        {
            velocidadAc = 12;
            movEscenario.instancia.velocidad = 23;
            caminoDinamico.instancia.velocidad = 25;
            velocidadBalaJ = 30;
            vidasE = 4;
            generadorObstaculos.instanciaControlador.puntoNuevoSpawn = 24;
            Physics.gravity = new Vector3(0, -15f, 0);
            movimiento.instancia.fuerzaSalto = 11f;
        }
        else if (nivelDificultad == 4)
        {
            movEscenario.instancia.velocidad = 26;
            caminoDinamico.instancia.velocidad = 30;
        }
        else if (nivelDificultad == 5)
        {
            movEscenario.instancia.velocidad = 29;
            caminoDinamico.instancia.velocidad = 35;
            velocidadBalaJ = 35;
            generadorObstaculos.instanciaControlador.puntoNuevoSpawn = 23;
            Physics.gravity = new Vector3(0, -21f, 0);
            movimiento.instancia.fuerzaSalto = 13f;
        }
        else if (nivelDificultad == 6)
        {
            velocidadAc = 14;
            movEscenario.instancia.velocidad = 32;
            caminoDinamico.instancia.velocidad = 40;
            vidasE = 5;
        }
        else if (nivelDificultad == 7)
        {
            movEscenario.instancia.velocidad = 35;
            caminoDinamico.instancia.velocidad = 45;
            velocidadBalaJ = 40;
            generadorObstaculos.instanciaControlador.puntoNuevoSpawn = 22;
        }
        else if (nivelDificultad == 8)
        {
            movEscenario.instancia.velocidad = 38;
            caminoDinamico.instancia.velocidad = 50;
        }
        else if (nivelDificultad == 9)
        {
            velocidadAc = 16;
            movEscenario.instancia.velocidad = 41;
            caminoDinamico.instancia.velocidad = 55;
            velocidadBalaJ = 45;
            vidasE = 6;
        }
    }
}
