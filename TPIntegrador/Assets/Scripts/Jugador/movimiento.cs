using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public static movimiento instancia;
    Animator animator;

    private Vector2 empiezaToque;
    private Vector2 terminaToque;

    public float distanciaToque = 35f;
    public float fuerzaSalto = 10f;
    private Rigidbody rb;

    public int contadorMonedas = 0;
    public bool monedasPUactivo = false;


    private void Awake()
    {
        instancia = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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
                        animator.SetTrigger("Jump");
                        Saltar();
                    }
                    else if (distanciaTocada < -distanciaToque)
                    {
                        animator.SetTrigger("Roll");
                    }
                    else
                    {
                        animator.Play("Run");
                    }
                    break;
            }
        }

    }

    void Saltar()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f) 
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            if(monedasPUactivo)
            {
                Debug.Log("ACTIVO");
                contadorMonedas += 2;
            } else
            {
                contadorMonedas++;
                Debug.Log("DESACTIVO");
            }
            Destroy(collision.gameObject);
        } else if(collision.gameObject.layer == 3 && (!collision.gameObject.name.Contains("FloorTrap")))
        {
            Menu.instancia.gameOver();
        } else if(collision.gameObject.CompareTag("monedasPU"))
        {
            monedasPUactivo = true;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("menosMonedasPu"))
        {
            if(contadorMonedas > 10)
            {
                contadorMonedas -= 10;
            } else
            {
                contadorMonedas = 0;
            }
            
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            if (other.gameObject.name.Contains("FloorTrap"))
            {
                Menu.instancia.gameOver();
                animator.SetTrigger("Death");
    
            }
        }
    }
}
