using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class MonedasPU : MonoBehaviour
{
    float tiempoPU = 10f;
    float tiempoTranscurrido = 0f;
    public bool monedasPUactivo = false;
    public TMP_Text monedasPU;
    public GameObject TextX2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movimiento.instancia.monedasPUactivo)
        {
            TextX2.gameObject.SetActive(true);
            monedasPU.color = Color.green;
            tiempoTranscurrido += Time.deltaTime;
            if(tiempoTranscurrido > tiempoPU)
            {
                movimiento.instancia.monedasPUactivo = false;
                tiempoTranscurrido = 0f;
                TextX2.gameObject.SetActive(false);
                monedasPU.color = Color.black;
            }
        }
    }
}
