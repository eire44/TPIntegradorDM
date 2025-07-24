using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaExtra : MonoBehaviour
{
    public static vidaExtra instancia;
    public GameObject pantallaUI;
    public Button vidaExtraBtn;
    public GameObject ImageVida;

    private void Awake()
    {
        instancia = this;
    }

    void Update()
    {
        if (TiendaManager.CargarVidaExtra())
        {
            ImageVida.SetActive(true);
        }
        else
        {
            ImageVida.SetActive(false);
        }
        
    }

    public void activarVidaExtra()
    {
        TiendaManager.GuardarRecord(false, 0, TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioAntorcha(), TiendaManager.CargarPrecioCasco(), TiendaManager.CargarIman(), false, TiendaManager.CargarEscudo(), TiendaManager.CargarAntorcha(), TiendaManager.CargarCasco());
    }
}
