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

    private void Awake()
    {
        instancia = this;
    }
    void Update()
    {
        if (TiendaManager.CargarIman() && pantallaUI.activeInHierarchy)
        {
            imanBtn.enabled = true;
        }
        else
        {
            imanBtn.enabled = false;
        }

        if (iniciarTiempo)
        {
            tiempoPU -= Time.deltaTime;
            if (tiempoPU < 0)
            {
                imanActivado.SetActive(false);
                tiempoPU = 10;
            }
        }
    }

    public void activarIman()
    {
        TiendaManager.GuardarRecord(false, 0, TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), false, TiendaManager.CargarVidaExtra(), TiendaManager.CargarEscudo());
        iniciarTiempo = true;
        imanActivado.SetActive(true);
    }
}
