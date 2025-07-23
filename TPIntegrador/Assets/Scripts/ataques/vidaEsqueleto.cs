using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaEsqueleto : MonoBehaviour
{
    int vidaActual = 3;
    int Daño = 1;
    public Slider SliderVida;
    public GameObject monedasPrefab;

    private void Start()
    {
        SliderVida.value = dificultad.instancia.vidasE;
        vidaActual = dificultad.instancia.vidasE;
    }
    void Update()
    {
        if(vidaActual == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                Transform nuevaMoneda = Instantiate(monedasPrefab.transform);
                nuevaMoneda.position = new Vector3(transform.position.x, 0f, transform.position.z + i * 2);
                movEscenario.instancia.obstaculosLista.Add(nuevaMoneda);
            }
            
            Destroy(gameObject);
        }
    }
    void RestarVida()
    {
        vidaActual -= Daño;
        ActualizarSlider();
    }
    void ActualizarSlider()
    {
        SliderVida.value = vidaActual;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                RestarVida();
            }
        }

    }
}
