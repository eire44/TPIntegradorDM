using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedasImantadas : MonoBehaviour
{
    Transform imanActivo;
    public float rangoIman = 5f;
    public float velocidadAtraccion = 10f;
    // Start is called before the first frame update
    void Start()
    {
        imanActivo = GameObject.FindGameObjectWithTag("Iman").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(iman.instancia.iniciarTiempo)
        {
            float distancia = Vector3.Distance(transform.position, imanActivo.position);

            if (distancia < rangoIman)
            {
                Vector3 direccion = (imanActivo.position - transform.position).normalized;
                transform.position += direccion * velocidadAtraccion * Time.deltaTime;
            }
        }
        
    }
}
