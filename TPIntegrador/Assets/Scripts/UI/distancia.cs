using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distancia : MonoBehaviour
{
    public Text distanciaText;
    float velocidad = 15f;
    float tiempoTranscurrido = 0;
    float distanciaRecorrida = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        distanciaRecorrida = velocidad * tiempoTranscurrido;
        distanciaText.text = ((int)distanciaRecorrida).ToString();
    }
}
