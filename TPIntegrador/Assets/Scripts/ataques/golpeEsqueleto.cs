using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golpeEsqueleto : MonoBehaviour
{
    public GameObject jugador;
    float rangoJugador = 30f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.transform.position);

        if (distancia < rangoJugador)
        {
            animator.SetTrigger("AtaqueEsqueleto");
            Vector3 direccion = jugador.transform.position - transform.position;
            Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, 10f * Time.deltaTime);
        }
    }
}
