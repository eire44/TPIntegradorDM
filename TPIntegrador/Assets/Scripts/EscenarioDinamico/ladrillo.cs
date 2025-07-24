using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladrillo : MonoBehaviour
{
    float velocidad = 10f;
    void Update()
    {
        if (gameObject.name.Contains("Clone"))
        {
            gameObject.transform.position += new Vector3(0, -1, 0) * velocidad * Time.deltaTime;
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
