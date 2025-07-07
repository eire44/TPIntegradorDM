using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedasImantadas : MonoBehaviour
{
    Transform jugador;
    public float rangoIman = 5f;
    public float velocidadAtraccion = 10f;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(iman.instancia.iniciarTiempo)
        {
            float distancia = Vector3.Distance(transform.position, jugador.position);

            if (distancia < rangoIman)
            {
                Vector3 direccion = (jugador.position - transform.position).normalized;
                transform.position += direccion * velocidadAtraccion * Time.deltaTime;
            }
        }
        
    }
}
