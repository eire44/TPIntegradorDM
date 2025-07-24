using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iman : MonoBehaviour
{
    public static iman instancia;
    public GameObject pantallaUI;
    public Button imanBtn;
    public GameObject imanActivado;

    float tiempoPU = 10f;
    public bool iniciarTiempo = false;
    public Animator animator;

    private void Awake()
    {
        instancia = this;
    }

    void Update()
    {
        if (TiendaManager.CargarIman() && pantallaUI.activeInHierarchy)
        {
            imanBtn.enabled = true;
            ColorBlock colors = imanBtn.colors;
            colors.normalColor = new Color(1, 1, 1, 1);
            imanBtn.colors = colors;
        }
        else
        {
            imanBtn.enabled = false;
            ColorBlock colors = imanBtn.colors;
            colors.normalColor = new Color(0.7f, 0.7f, 0.7f, 0.5f);
            imanBtn.colors = colors;
        }

        if (iniciarTiempo)
        {
            tiempoPU -= Time.deltaTime;
            if (tiempoPU < 0)
            {
                iniciarTiempo = false;
                imanActivado.SetActive(false);
                animator.SetBool("Iman", false);
                tiempoPU = 10;
            }
        }
    }

    public void activarIman()
    {
        TiendaManager.GuardarRecord(false, 0, TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioAntorcha(), TiendaManager.CargarPrecioCasco(), false, TiendaManager.CargarVidaExtra(), TiendaManager.CargarEscudo(), TiendaManager.CargarAntorcha(), TiendaManager.CargarCasco());
        iniciarTiempo = true;
        imanActivado.SetActive(true);
        animator.SetBool("Iman", true);
    }
}
