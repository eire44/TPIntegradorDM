using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dificultad : MonoBehaviour
{
    public static dificultad instancia;
    public int velocidadAc = 10;
    public int nivelDificultad = 1;
    public float velocidadBalaJ = 25f;

    private void Awake()
    {
        instancia = this;
    }
    // Start is called before the first frame update
    void Start()
    {

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
            movEscenario.instancia.velocidad = 25;
            caminoDinamico.instancia.velocidad = 25;
            velocidadBalaJ = 30;
        }
        else if (nivelDificultad == 4)
        {
            movEscenario.instancia.velocidad = 30;
            caminoDinamico.instancia.velocidad = 30;
        }
        else if (nivelDificultad == 5)
        {
            movEscenario.instancia.velocidad = 35;
            caminoDinamico.instancia.velocidad = 35;
            velocidadBalaJ = 35;
        }
        else if (nivelDificultad == 6)
        {
            velocidadAc = 14;
            movEscenario.instancia.velocidad = 40;
            caminoDinamico.instancia.velocidad = 40;
        }
        else if (nivelDificultad == 7)
        {
            movEscenario.instancia.velocidad = 45;
            caminoDinamico.instancia.velocidad = 45;
            velocidadBalaJ = 40;
        }
        else if (nivelDificultad == 8)
        {
            movEscenario.instancia.velocidad = 50;
            caminoDinamico.instancia.velocidad = 50;
        }
        else if (nivelDificultad == 9)
        {
            velocidadAc = 16;
            movEscenario.instancia.velocidad = 55;
            caminoDinamico.instancia.velocidad = 55;
            velocidadBalaJ = 45;
        }
    }
}
