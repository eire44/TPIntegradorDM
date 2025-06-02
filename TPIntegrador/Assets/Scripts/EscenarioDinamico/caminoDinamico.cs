using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminoDinamico : MonoBehaviour
{
    public static caminoDinamico instancia;

    public GameObject camino;
    float spacingZ = 7.5f;
    public float velocidad = 15f;

    private List<Transform> caminoLista = new List<Transform>();
    private float tiempoEntreSpawns = 0.8f;
    private float tiempoSiguienteSpawn = 0f;
    private float zActual = 80f;


    private void Awake()
    {
        instancia = this;
    }

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Floor"))
            {
                caminoLista.Add(child);
            }
        }
        //for (int i = 0; i < 15; i++)
        //{
        //    GameObject nuevoBloque = Instantiate(camino);
        //    nuevoBloque.transform.position = new Vector3(0f, -1f, zActual);
        //    caminoLista.Add(nuevoBloque.transform);

        //    zActual += spacingZ;
        //}
    }

    void Update()
    {

        if (Time.time >= tiempoSiguienteSpawn)
        {
            GameObject nuevoBloque = Instantiate(camino);
            nuevoBloque.transform.position = new Vector3(0f, -1f, zActual);

            caminoLista.Add(nuevoBloque.transform);

            zActual += spacingZ;


            //if (controladorObstaculos.instanciaControlador.noGenerarPiso)
            //{
            //    for (int i = 0; i < caminoLista.Count; i++)
            //    {
            //        Transform bloque = caminoLista[i];

            //        if (bloque.position.z >= controladorObstaculos.instanciaControlador.puntoDeSpawn - 5 && bloque.position.z <= controladorObstaculos.instanciaControlador.puntoDeSpawn + 4)
            //        {
            //            Destroy(bloque.gameObject);
            //            caminoLista.RemoveAt(i);
            //            i--;
            //        }
            //    }
            //    controladorObstaculos.instanciaControlador.noGenerarPiso = false;
            //    controladorObstaculos.instanciaControlador.spawneando = false;
            //}


            tiempoSiguienteSpawn = Time.time + tiempoEntreSpawns;
        }

        //if (ultimoBloque.z <= (zActual - 4))
        //{
        //    //generarSiguienteBloque = true;
        //    
        //}

        moverYDestruirCamino();
    }

    void moverYDestruirCamino()
    {
        for (int i = 0; i < caminoLista.Count; i++)
        {
            Transform bloque = caminoLista[i];
            if (bloque == null) continue;

            bloque.position += Vector3.back * velocidad * Time.deltaTime;

            if (bloque.position.z < -30f)
            {
                Destroy(bloque.gameObject);
                caminoLista.RemoveAt(i);
                i--;
            }
        }
    }
}
