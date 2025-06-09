using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaEsqueleto : MonoBehaviour
{
    //int contadorDaño = 0;
    int vidaTotal = 3;
    int Daño = 1;
    public Slider SliderVida;

    private void Start()
    {
        SliderVida.value = vidaTotal;
    }
    void Update()
    {
        if(vidaTotal == 0)
        {
            Destroy(gameObject);
        }
    }
    void RestarVida()
    {
        vidaTotal -= Daño;
        ActualizarSlider();
    }
    void ActualizarSlider()
    {
        SliderVida.value = vidaTotal;
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                RestarVida();
            }
        }

    }
}
