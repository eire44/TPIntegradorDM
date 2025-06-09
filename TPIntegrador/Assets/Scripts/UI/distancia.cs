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
        distanciaRecorrida = velocidad * tiempoTranscurrido;
        distanciaText.text = ((int)distanciaRecorrida).ToString();
    }
}
