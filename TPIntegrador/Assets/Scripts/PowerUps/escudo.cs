using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escudo : MonoBehaviour
{
    public GameObject pantallaUI;
    public Button escudoBtn;
    public GameObject escudoActivado;

    float tiempoPU = 10f;
    bool iniciarTiempo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TiendaManager.CargarEscudo() && pantallaUI.activeInHierarchy)
        {
            escudoBtn.enabled = true;
            ColorBlock colors = escudoBtn.colors;
            colors.normalColor = new Color(1, 1, 1, 1);
            escudoBtn.colors = colors;
        }
        else
        {
            escudoBtn.enabled = false;
            ColorBlock colors = escudoBtn.colors;
            colors.normalColor = new Color(0.7f, 0.7f, 0.7f, 0.5f);
            escudoBtn.colors = colors;
        }

        if(iniciarTiempo)
        {
            tiempoPU -= Time.deltaTime;
            if(tiempoPU < 0)
            {
                escudoActivado.SetActive(false);
                tiempoPU = 10;
            }
        }
    }


    public void activarEscudo()
    {
        TiendaManager.GuardarRecord(false, 0, TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarIman(), TiendaManager.CargarVidaExtra(), false);
        iniciarTiempo = true;
        escudoActivado.SetActive(true);
    }
}
