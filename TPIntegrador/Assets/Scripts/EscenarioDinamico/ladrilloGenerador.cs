using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladrilloGenerador : MonoBehaviour
{
    float tiempoSpawn = 10f;
    public GameObject brick;
    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSpawn -= Time.deltaTime;

        if (tiempoSpawn <= 0f)
        {
            tiempoSpawn = 10f;

            int probabilidad = Random.Range(0, 7);

            if (probabilidad == 0)
            {
                Debug.Log("LADRILLO");
                GameObject ladrillo = Instantiate(brick);

                int carrilX = Random.Range(-1, 2);
                ladrillo.transform.position = new Vector3(carrilX, 9f, jugador.transform.position.z);
            }
        }
    }
}
