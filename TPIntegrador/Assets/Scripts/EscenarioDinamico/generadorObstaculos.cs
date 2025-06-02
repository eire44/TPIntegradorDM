using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorObstaculos : MonoBehaviour
{
    public static generadorObstaculos instanciaControlador;

    public bool spawneando = false;

    float timerSpawnear = 0f;
    float tiempoSpawn = 3f;

    public int generador;
    public float puntoDeSpawn = 70f;

    private void Awake()
    {
        instanciaControlador = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timerSpawnear = tiempoSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawneando)
        {
            timerSpawnear -= Time.deltaTime;
        }


        if (timerSpawnear <= 0f && !spawneando)
        {
            timerSpawnear = tiempoSpawn;

            //generador = Random.Range(0, 4);
            //Debug.Log(generador);

            //if (generador == 0)
            //{
                spawneando = true;
                obstaculos.instancia.spawnearObstaculo();
            //}
            //else if (generador == 1)
            //{
            //    spawneando = true;
            //}
            //else if (generador == 2)
            //{
            //    spawneando = true;


            //}
            //else if (generador == 3)
            //{
            //    spawneando = true;

            //    if (Random.Range(0, 100) < 50)
            //    {
            //    }


            //}
        }
    }
}
