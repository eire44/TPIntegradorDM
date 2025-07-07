using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tienda : MonoBehaviour
{
    public TMP_Text precioIman;
    public TMP_Text precioVidaExtra;
    public TMP_Text precioEscudo;

    public TMP_Text monedasTotales;

    public Button Iman;
    public Button VidaExtra;
    public Button Escudo;
    // Start is called before the first frame update
    void Start()
    {
        precioIman.text = TiendaManager.CargarPrecioIman().ToString();
        precioVidaExtra.text = TiendaManager.CargarPrecioVidaExtra().ToString();
        precioEscudo.text = TiendaManager.CargarPrecioEscudo().ToString();
        monedasTotales.text = TiendaManager.CargarCantMonedas().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(RecordManager.CargarCantMonedas() > TiendaManager.CargarPrecioIman())
        {
            Iman.enabled = true;
        } else
        {
            Iman.enabled = false;
        }

        if (RecordManager.CargarCantMonedas() > TiendaManager.CargarPrecioVidaExtra())
        {
            VidaExtra.enabled = true;
        }
        else
        {
            VidaExtra.enabled = false;
        }

        if (RecordManager.CargarCantMonedas() > TiendaManager.CargarPrecioEscudo())
        {
            Escudo.enabled = true;
        }
        else
        {
            Escudo.enabled = false;
        }
    }

    public void comprarIman()
    {
        actualizarTienda(TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioIman() + 10, TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), true, TiendaManager.CargarVidaExtra(), TiendaManager.CargarEscudo());

        precioIman.text = TiendaManager.CargarPrecioIman().ToString();
        monedasTotales.text = TiendaManager.CargarCantMonedas().ToString();
    }

    public void comprarVidaExtra()
    {
        actualizarTienda(TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra() + 10, TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarIman(), true, TiendaManager.CargarEscudo());

        precioVidaExtra.text = TiendaManager.CargarPrecioIman().ToString();
        monedasTotales.text = TiendaManager.CargarCantMonedas().ToString();
    }

    public void comprarEscudo()
    {
        actualizarTienda(TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo() + 10, TiendaManager.CargarIman(), TiendaManager.CargarVidaExtra(), true);

        precioEscudo.text = TiendaManager.CargarPrecioIman().ToString();
        monedasTotales.text = TiendaManager.CargarCantMonedas().ToString();
    }

    void actualizarTienda(int precio, int precioIman, int precioVidaExtra, int precioEscudo, bool Iman, bool VidaExtra, bool Escudo)
    {
        TiendaManager.GuardarRecord(false, RecordManager.CargarCantMonedas() - precio, precioIman, precioVidaExtra, precioEscudo, Iman, VidaExtra, Escudo);
    }
}
