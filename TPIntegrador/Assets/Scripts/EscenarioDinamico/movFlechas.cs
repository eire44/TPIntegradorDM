using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movFlechas : MonoBehaviour
{
    public float velocidad = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name.Contains("Clone"))
        {
            gameObject.transform.position += transform.forward * -1 * velocidad * Time.deltaTime;
            gameObject.transform.position += new Vector3(0, 0, -1) * velocidad * Time.deltaTime;
        }

        if (gameObject.transform.position.z < -15f)
        {
            Destroy(gameObject.transform.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.name.Contains("Clone"))
        {
            Destroy(gameObject);
        }
    }
}
