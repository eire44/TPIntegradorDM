using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class monedas : MonoBehaviour
{
    public static monedas instancia;

    public GameObject monedasPrefab;
    List<Transform> monedasLista;
    Transform nuevaMoneda;

    private void Awake()
    {
        instancia = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        monedasLista = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        destruirObstaculo();
    }

    public void spawnearObstaculo()
    {
        int carrilX = Random.Range(-1, 2);
        int cantidad = Random.Range(3, 6);
        float posY = 0f;

        for (int i = 0; i < cantidad; i++)
        {
            nuevaMoneda = Instantiate(monedasPrefab.transform);
            //nuevoObstaculo.position = new Vector3(0f, 0f, generadorObstaculos.instanciaControlador.puntoDeSpawn);

            nuevaMoneda.position = new Vector3(carrilX, posY, generadorObstaculos.instanciaControlador.aumentarPuntoSpawn(4f));


            monedasLista.Add(nuevaMoneda);
        }
        generadorObstaculos.instanciaControlador.spawneando = false;
    }

    void destruirObstaculo()
    {
        for (int i = 0; i < monedasLista.Count; i++)
        {
            Transform moneda = monedasLista[i];
            if (moneda != null)
            {
                moneda.position += new Vector3(0, 0, -1) * 15f * Time.deltaTime;

                if (moneda.position.z < -15f)
                {
                    Destroy(moneda.gameObject);
                    monedasLista.Remove(moneda);
                    i--;
                }
            }

        }
    }
}
