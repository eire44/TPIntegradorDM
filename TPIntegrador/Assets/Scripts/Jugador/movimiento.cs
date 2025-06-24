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
    [HideInInspector] public float fuerzaSalto = 8.5f;
    private Rigidbody rb;

    public int contadorMonedas = 0;
    public bool monedasPUactivo = false;
    public bool escudoPUactivo = false;

    public GameObject TextMenos10;

    float crouchColliderHeight = 1f;
    public float crouchTransitionSpeed = 1f;
    private BoxCollider capsuleCollider;
    private bool isCrouching = false;
    private float tiempoRoll = 2f;
    private void Awake()
    {
        instancia = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if(isCrouching)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, -1f, Time.deltaTime * crouchTransitionSpeed), transform.position.z);
            capsuleCollider.size = new Vector3(capsuleCollider.size.x, Mathf.Lerp(capsuleCollider.size.y, crouchColliderHeight, Time.deltaTime * crouchTransitionSpeed), capsuleCollider.size.z);
            tiempoRoll -= Time.deltaTime;
            if(tiempoRoll < 0)
            {
                isCrouching = false;
                capsuleCollider.size = new Vector3(capsuleCollider.size.x, 1.818104f, capsuleCollider.size.z);
                capsuleCollider.center = new Vector3(capsuleCollider.center.x, 0.9190524f, capsuleCollider.center.z);
                tiempoRoll = 2f;
            }
        }


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
                        isCrouching = true;
                        //capsuleCollider.size = new Vector3(capsuleCollider.size.x, crouchColliderHeight, capsuleCollider.size.z);
                        capsuleCollider.center = new Vector3(capsuleCollider.center.x, 0.5f, capsuleCollider.center.z);
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
                contadorMonedas += 2;
            } else
            {
                contadorMonedas++;
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

            TextMenos10.SetActive(true);
            StartCoroutine(DesactivarTextoMenos10());

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("escudoPU"))
        {
            escudoPUactivo = true;
            Destroy(collision.gameObject);
        }
    }
    IEnumerator DesactivarTextoMenos10()
    {
        yield return new WaitForSeconds(2f); 
        TextMenos10.SetActive(false);
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
