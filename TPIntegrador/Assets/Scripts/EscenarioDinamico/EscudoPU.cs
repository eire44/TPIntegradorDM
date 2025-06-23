using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class EscudoPU : MonoBehaviour
{
    float tiempoPU = 10f;
    float tiempoTranscurrido = 0f;
    public bool escudoPUactivo = false;
    public BoxCollider colliderJugador;
    public GameObject escudo;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movimiento.instancia.escudoPUactivo)
        {
            escudo.SetActive(true);
            colliderJugador.excludeLayers = 1 << LayerMask.NameToLayer("Enemies");
            tiempoTranscurrido += Time.deltaTime;
            if (tiempoTranscurrido > tiempoPU)
            {
                escudo.SetActive(false);
                colliderJugador.excludeLayers = 0;
                movimiento.instancia.escudoPUactivo = false;
                tiempoTranscurrido = 0f;
            }
        }
    }
}
