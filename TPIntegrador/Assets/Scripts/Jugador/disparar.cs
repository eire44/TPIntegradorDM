using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    float velocidadBala = 25f;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void disparo()
    {
        velocidadBala = dificultad.instancia.velocidadBalaJ;
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation * Quaternion.Euler(90, 0, 0));
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = puntoDisparo.forward * velocidadBala;
        animator.SetTrigger("Shoot");
    }
}
