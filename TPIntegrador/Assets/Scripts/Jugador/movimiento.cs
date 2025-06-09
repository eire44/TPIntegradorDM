using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public static movimiento instancia;
    //Animator animator;

    private Vector2 empiezaToque;
    private Vector2 terminaToque;

    public float distanciaToque = 35f;
    public float fuerzaSalto = 10f;
    private Rigidbody rb;

    public int contadorMonedas = 0;


    private void Awake()
    {
        instancia = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            switch (toque.phase)
            {
                case TouchPhase.Began:
                    empiezaToque = toque.position;
                    break;

                case TouchPhase.Ended:
                    terminaToque = toque.position;


                    float distanciaTocada = terminaToque.y - empiezaToque.y;
                    if (distanciaTocada > distanciaToque)
                    {
                        //animator.SetTrigger("jump");
                        Saltar();
                    }
                    else if (distanciaTocada < -distanciaToque)
                    {
                        //animator.SetTrigger("slide");
                    }
                    else
                    {

                    }
                    break;
            }
        }

    }

    void Saltar()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f) //Evita volver a saltar si aún no aterrizó
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            contadorMonedas++;
            Destroy(collision.gameObject);
        } else if(collision.gameObject.layer == 3)
        {
            Menu.instancia.gameOver();
        }
    }
}
