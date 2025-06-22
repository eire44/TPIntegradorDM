using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedasPU : MonoBehaviour
{
    float tiempoPU = 10f;
    float tiempoTranscurrido = 0f;
    public bool monedasPUactivo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movimiento.instancia.monedasPUactivo)
        {
            tiempoTranscurrido += Time.deltaTime;
            if(tiempoTranscurrido > tiempoPU)
            {
                movimiento.instancia.monedasPUactivo = false;
                tiempoTranscurrido = 0f;
            }
        }
    }
}
