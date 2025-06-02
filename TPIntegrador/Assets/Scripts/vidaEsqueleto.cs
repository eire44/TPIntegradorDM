using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEsqueleto : MonoBehaviour
{
    int contadorDaño = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(contadorDaño >= 3)
        {
            Destroy(gameObject);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                contadorDaño++;
            }
        }

    }
}
