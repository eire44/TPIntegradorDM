using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class caminoDinamico : MonoBehaviour
{
    public static caminoDinamico instancia;

    public GameObject camino;
    public GameObject trampa;
    public float velocidad = 15f;

    public bool trampaSpawn = false;
    public List<Transform> pisoLista = new List<Transform>();
    [HideInInspector] public float puntoDeSpawn = 120f;
    public bool spawneando = false;

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
                pisoLista.Add(child);
            }
        }
    }

    void Update()
    {
        if (pisoLista.Count > 0)
        {
            Transform ultimoSpawn = pisoLista[pisoLista.Count - 1];

            if ((!spawneando) && ((ultimoSpawn.transform.position.z <= (puntoDeSpawn - 18)) || ultimoSpawn == null))
            {
                // && ((movEscenario.instancia.obstaculosLista.Count == 1) || (movEscenario.instancia.obstaculosLista.Count == 0))
                spawneando = true;
                generarPiso();
            }
        }
        else
        {
            spawneando = true;
            generarPiso();
        }

        destruirObstaculo();
    }

    void generarPiso()
    {
        GameObject nuevoBloque;
        if (trampaSpawn)
        {
            trampaSpawn = false;

            int intentos = 0;
            int maxIntentos = 3;
            float posZ = puntoDeSpawn;
            while (generadorObstaculos.instanciaControlador.verificarPosicion(posZ) && intentos < maxIntentos)
            {
                intentos++;
            }

            if (intentos < maxIntentos)
            {
                nuevoBloque = Instantiate(trampa);
                nuevoBloque.transform.position = new Vector3(0f, -4.71f, puntoDeSpawn);
                movEscenario.instancia.obstaculosLista.Add(nuevoBloque.transform);
                generadorObstaculos.instanciaControlador.spawneando = false;
            }
            else
            {
                Debug.Log("CAMBIO EN X DE " + trampa.name);
                nuevoBloque = Instantiate(camino);
                nuevoBloque.transform.position = new Vector3(0f, -1f, puntoDeSpawn);
                generadorObstaculos.instanciaControlador.spawneando = false;
            }

            //if (generadorObstaculos.instanciaControlador.verificarPosicion(puntoDeSpawn))
            //{
            //    Debug.Log("CAMBIO EN X DE " + trampa.name);
            //    nuevoBloque = Instantiate(camino);
            //    nuevoBloque.transform.position = new Vector3(0f, -1f, puntoDeSpawn);
            //    generadorObstaculos.instanciaControlador.spawneando = false;
            //} else
            //{
            //    nuevoBloque = Instantiate(trampa);
            //    nuevoBloque.transform.position = new Vector3(0f, -4.71f, puntoDeSpawn);
            //    movEscenario.instancia.obstaculosLista.Add(nuevoBloque.transform);
            //    generadorObstaculos.instanciaControlador.spawneando = false;
            //}
        }
        else
        {
            nuevoBloque = Instantiate(camino);
            nuevoBloque.transform.position = new Vector3(0f, -1f, puntoDeSpawn);
            //generadorObstaculos.instanciaControlador.noSpawn = false;
        }

        pisoLista.Add(nuevoBloque.transform);
        spawneando = false;
        
    }

    void destruirObstaculo()
    {
        for (int i = 0; i < pisoLista.Count; i++)
        {
            Transform obstaculo = pisoLista[i];
            if (obstaculo != null)
            {
                obstaculo.position += new Vector3(0, 0, -1) * velocidad * Time.deltaTime;

                if (obstaculo.position.z < -30f)
                {
                    Destroy(obstaculo.gameObject);
                    pisoLista.Remove(obstaculo);
                    movEscenario.instancia.obstaculosLista.Remove(obstaculo);
                    i--;
                }
            }

        }
    }
}
