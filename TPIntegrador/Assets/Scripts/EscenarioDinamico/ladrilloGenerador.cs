using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladrilloGenerador : MonoBehaviour
{
    float tiempoSpawn = 10f;
    float tiempoCuidado = 2f;
    public GameObject brick;
    public GameObject jugador;
    public GameObject cuidado;
    bool generar = false;
    void Update()
    {
        tiempoSpawn -= Time.deltaTime;

        if (tiempoSpawn <= 0f && !generar)
        {
            tiempoSpawn = 10f;

            int probabilidad = Random.Range(0, 7);

            if (probabilidad == 0)
            {
                Debug.Log("LADRILLO");
                cuidado.SetActive(true);
                generar = true;

            }
        }

        if (generar)
        {
            tiempoCuidado -= Time.deltaTime;
            if (tiempoCuidado <= 0f)
            {
                generar = false;
                tiempoCuidado = 2f;
                cuidado.SetActive(false);
                GameObject ladrillo = Instantiate(brick);

                int carrilX = Random.Range(-1, 2);
                ladrillo.transform.position = new Vector3(carrilX, 8.02f, jugador.transform.position.z);
            }

        }
    }
}
