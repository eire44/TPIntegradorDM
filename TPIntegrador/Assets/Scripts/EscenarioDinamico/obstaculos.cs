using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculos : MonoBehaviour
{
    public static obstaculos instancia;
    public GameObject caja;
    public GameObject barril;
    public GameObject columna;
    public GameObject escombros;
    public GameObject esqueleto;
    List<Transform> obstaculosLista;

    Transform nuevoObstaculo;

    private void Awake()
    {
        instancia = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        obstaculosLista = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        destruirObstaculo();
    }

    public void spawnearObstaculo()
    {
        int obstaculoTipo = Random.Range(0, 5);
        int carrilX = Random.Range(-1, 2);

        float posY = 0f;

        if (obstaculoTipo == 0)
        {
            nuevoObstaculo = Instantiate(caja.transform);
            //nuevoObstaculo.position = new Vector3(0f, 0f, generadorObstaculos.instanciaControlador.puntoDeSpawn);
        }
        else if (obstaculoTipo == 1)
        {
            nuevoObstaculo = Instantiate(barril.transform);
            //nuevoObstaculo.position = new Vector3(0f, 0f, generadorObstaculos.instanciaControlador.puntoDeSpawn);
        }
        else if(obstaculoTipo == 2) 
        {
            nuevoObstaculo = Instantiate(columna.transform);
            carrilX = 0;
            posY = -1;
            //nuevoObstaculo.position = new Vector3(0f, -1f, generadorObstaculos.instanciaControlador.puntoDeSpawn);
        }
        else if (obstaculoTipo == 3)
        {
            nuevoObstaculo = Instantiate(escombros.transform);
            carrilX = 0;
        } else
        {
            nuevoObstaculo = Instantiate(esqueleto.transform);
        }

        nuevoObstaculo.position = new Vector3(carrilX, posY, generadorObstaculos.instanciaControlador.puntoDeSpawn);


        obstaculosLista.Add(nuevoObstaculo);

        generadorObstaculos.instanciaControlador.spawneando = false;
    }

    void destruirObstaculo()
    {
        for (int i = 0; i < obstaculosLista.Count; i++)
        {
            Transform obstaculo = obstaculosLista[i];
            if (obstaculo != null)
            {
                obstaculo.position += new Vector3(0, 0, -1) * 15f * Time.deltaTime;

                if (obstaculo.position.z < -15f)
                {
                    Destroy(obstaculo.gameObject);
                    obstaculosLista.Remove(obstaculo);
                    i--;
                }
            }

        }
    }
}
