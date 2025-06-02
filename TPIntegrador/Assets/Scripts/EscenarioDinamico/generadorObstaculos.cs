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
    [HideInInspector]  public float puntoDeSpawn = 80f;

    public bool noSpawn = false;
    float spacingZ = 7.5f;

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
        if (!spawneando && !noSpawn)
        {
            timerSpawnear -= Time.deltaTime;
        }


        if (timerSpawnear <= 0f && !spawneando && !noSpawn)
        {
            timerSpawnear = tiempoSpawn;

            generador = Random.Range(0, 3);

            if ((generador == 0 || generador == 1) && !noSpawn)
            {
                spawneando = true;
                obstaculos.instancia.spawnearObstaculo();
                puntoDeSpawn += spacingZ;
            }
            else if (generador == 2)
            {
                spawneando = true;
                noSpawn = true;
                caminoDinamico.instancia.trampaSpawn = true;
            }
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
