using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaExtra : MonoBehaviour
{
    public static vidaExtra instancia;
    public GameObject pantallaUI;
    public Button vidaExtraBtn;

    private void Awake()
    {
        instancia = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activarVidaExtra()
    {
        TiendaManager.GuardarRecord(false, 0, TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarIman(), false, TiendaManager.CargarEscudo());
    }
}
