using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class distancia : MonoBehaviour
{
    public static distancia instancia;
    public TMP_Text distanciaText;
    float velocidad = 10f;
    float tiempoTranscurrido = 0;
    public float distanciaRecorrida = 0;

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
        tiempoTranscurrido += Time.deltaTime;
        distanciaRecorrida = movEscenario.instancia.velocidad * tiempoTranscurrido;
        distanciaText.text = ((int)distanciaRecorrida).ToString();


        if (distanciaRecorrida > 200 && dificultad.instancia.nivelDificultad == 1)
        {
            dificultad.instancia.nivelDificultad++;
        }
        else if (distanciaRecorrida > 450 && dificultad.instancia.nivelDificultad == 2)
        {
            dificultad.instancia.nivelDificultad++;
        }
        else if (distanciaRecorrida > 750 && dificultad.instancia.nivelDificultad == 3)
        {
            dificultad.instancia.nivelDificultad++;
        }
        else if (distanciaRecorrida > 1100 && dificultad.instancia.nivelDificultad == 4)
        {
            dificultad.instancia.nivelDificultad++;
        }
        else if (distanciaRecorrida > 1500 && dificultad.instancia.nivelDificultad == 5)
        {
            dificultad.instancia.nivelDificultad++;
        }
        else if (distanciaRecorrida > 1950 && dificultad.instancia.nivelDificultad == 6)
        {
            dificultad.instancia.nivelDificultad++;
        }
        else if (distanciaRecorrida > 2450 && dificultad.instancia.nivelDificultad == 7)
        {
            dificultad.instancia.nivelDificultad++;
        }
        else if (distanciaRecorrida > 3000 && dificultad.instancia.nivelDificultad == 8)
        {
            dificultad.instancia.nivelDificultad++;
        }
    }
}
