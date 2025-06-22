using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispararFlechas : MonoBehaviour
{
    public GameObject arrows;
    float tiempoSpawn = 1.5f;
    float tiempo = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if(tiempo >= tiempoSpawn)
        {
            tiempo = 0f;
            spawnear();
        }
    }

    void spawnear()
    {
        if(gameObject.name.Contains("Clone"))
        {
            float posY = transform.position.y - 1f;
            for (int i = 0; i < 3; i++)
            {
                GameObject flecha = Instantiate(arrows);
                flecha.transform.position = new Vector3(transform.position.x - 1.1f, posY, transform.position.z);
                posY += 1f;
            }
        }
    }
}
