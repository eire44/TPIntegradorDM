using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acelerometro : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        Vector3 movimiento = Input.acceleration;
        transform.Translate(movimiento.x * speed * Time.deltaTime, 0, 0);
    }
}
