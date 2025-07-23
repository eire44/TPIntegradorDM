using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminarBala : MonoBehaviour
{
    public GameObject monedasPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.z > 120)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.CompareTag("Destroyable"))
            {
                if(collision.gameObject.name.Contains("Barrel"))
                {
                    Transform nuevaMoneda = Instantiate(monedasPrefab.transform);
                    nuevaMoneda.position = new Vector3(collision.transform.position.x, 0f, collision.transform.position.z);
                    movEscenario.instancia.obstaculosLista.Add(nuevaMoneda);

                }
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }

    }
}
