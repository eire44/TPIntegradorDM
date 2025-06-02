using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminarBala : MonoBehaviour
{
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
            Debug.Log("eliminada");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
