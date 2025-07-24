using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class antorcha : MonoBehaviour
{
    public static antorcha instancia;
    public GameObject pantallaUI;
    public Button antorchaBtn;
    public GameObject antorchaActivado;

    float tiempoPU = 15f;
    public bool iniciarTiempo = false;
    public Animator animator;

    private void Awake()
    {
        instancia = this;
    }

    void Update()
    {
        if (TiendaManager.CargarAntorcha() && pantallaUI.activeInHierarchy)
        {
            antorchaBtn.enabled = true;
            ColorBlock colors = antorchaBtn.colors;
            colors.normalColor = new Color(1, 1, 1, 1);
            antorchaBtn.colors = colors;
        }
        else
        {
            antorchaBtn.enabled = false;
            ColorBlock colors = antorchaBtn.colors;
            colors.normalColor = new Color(0.7f, 0.7f, 0.7f, 0.5f);
            antorchaBtn.colors = colors;
        }

        if (iniciarTiempo)
        {
            tiempoPU -= Time.deltaTime;
            if (tiempoPU < 0)
            {
                iniciarTiempo = false;
                antorchaActivado.SetActive(false);
                animator.SetBool("antorcha", false);
                tiempoPU = 15;
            }
        }
    }

    public void activarAntorcha()
    {
        TiendaManager.GuardarRecord(false, 0, TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioAntorcha(), TiendaManager.CargarPrecioCasco(), TiendaManager.CargarIman(), TiendaManager.CargarVidaExtra(), TiendaManager.CargarEscudo(), false, TiendaManager.CargarCasco());
        iniciarTiempo = true;
        antorchaActivado.SetActive(true);
        animator.SetBool("antorcha", true);
    }
}
