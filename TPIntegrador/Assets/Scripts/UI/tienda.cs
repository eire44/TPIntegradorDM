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
    public TMP_Text precioAntorcha;
    public TMP_Text precioCasco;

    public TMP_Text monedasTotales;

    public Button Iman;
    public Button VidaExtra;
    public Button Escudo;
    public Button Antorcha;
    public Button Casco;
    // Start is called before the first frame update
    void Start()
    {
        //TiendaManager.reiniciarValores();
        precioIman.text = TiendaManager.CargarPrecioIman().ToString();
        precioVidaExtra.text = TiendaManager.CargarPrecioVidaExtra().ToString();
        precioEscudo.text = TiendaManager.CargarPrecioEscudo().ToString();
        precioAntorcha.text = TiendaManager.CargarPrecioAntorcha().ToString();
        precioCasco.text = TiendaManager.CargarPrecioCasco().ToString();
        monedasTotales.text = TiendaManager.CargarCantMonedas().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(TiendaManager.CargarCantMonedas() >= TiendaManager.CargarPrecioIman())
        {
            if(TiendaManager.CargarIman())
            {
                desactivarBoton(Iman);
            } else
            {
                activarBoton(Iman);
            }
        } else
        {
            desactivarBoton(Iman);
        }

        if (TiendaManager.CargarCantMonedas() >= TiendaManager.CargarPrecioVidaExtra())
        {
            if (TiendaManager.CargarVidaExtra())
            {
                desactivarBoton(VidaExtra);
            }
            else
            {
                activarBoton(VidaExtra);
            }
        }
        else
        {
            desactivarBoton(VidaExtra);
        }

        if (TiendaManager.CargarCantMonedas() >= TiendaManager.CargarPrecioEscudo())
        {
            if (TiendaManager.CargarEscudo())
            {
                desactivarBoton(Escudo);
            }
            else
            {
                activarBoton(Escudo);
            }
        }
        else
        {
            desactivarBoton(Escudo);
        }


        if (TiendaManager.CargarCantMonedas() >= TiendaManager.CargarPrecioAntorcha())
        {
            if (TiendaManager.CargarAntorcha())
            {
                desactivarBoton(Antorcha);
            }
            else
            {
                activarBoton(Antorcha);
            }
        }
        else
        {
            desactivarBoton(Antorcha);
        }


        if (TiendaManager.CargarCantMonedas() >= TiendaManager.CargarPrecioCasco())
        {
            if (TiendaManager.CargarCasco())
            {
                desactivarBoton(Casco);
            }
            else
            {
                activarBoton(Casco);
            }
        }
        else
        {
            desactivarBoton(Casco);
        }
    }

    void activarBoton(Button boton)
    {
        boton.enabled = true;
        ColorBlock colors = boton.colors;
        colors.normalColor = new Color(1, 1, 1, 1);
        boton.colors = colors;
    }
    void desactivarBoton(Button boton)
    {
        boton.enabled = false;
        ColorBlock colors = boton.colors;
        colors.normalColor = new Color(0.7f, 0.7f, 0.7f, 0.5f);
        boton.colors = colors;

    }

    public void comprarIman()
    {
        actualizarTienda(TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioIman() + 10, TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioAntorcha(), TiendaManager.CargarPrecioCasco(), true, TiendaManager.CargarVidaExtra(), TiendaManager.CargarEscudo(), TiendaManager.CargarAntorcha(), TiendaManager.CargarCasco());

        precioIman.text = TiendaManager.CargarPrecioIman().ToString();
        monedasTotales.text = TiendaManager.CargarCantMonedas().ToString();
    }

    public void comprarVidaExtra()
    {
        actualizarTienda(TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra() + 10, TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioAntorcha(), TiendaManager.CargarPrecioCasco(), TiendaManager.CargarIman(), true, TiendaManager.CargarEscudo(), TiendaManager.CargarAntorcha(), TiendaManager.CargarCasco());

        precioVidaExtra.text = TiendaManager.CargarPrecioVidaExtra().ToString();
        monedasTotales.text = TiendaManager.CargarCantMonedas().ToString();
    }

    public void comprarEscudo()
    {
        actualizarTienda(TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo() + 10, TiendaManager.CargarPrecioAntorcha(), TiendaManager.CargarPrecioCasco(), TiendaManager.CargarIman(), TiendaManager.CargarVidaExtra(), true, TiendaManager.CargarAntorcha(), TiendaManager.CargarCasco());

        precioEscudo.text = TiendaManager.CargarPrecioEscudo().ToString();
        monedasTotales.text = TiendaManager.CargarCantMonedas().ToString();
    }

    public void comprarAntorcha()
    {
        actualizarTienda(TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioAntorcha() + 10, TiendaManager.CargarPrecioCasco(), TiendaManager.CargarIman(), TiendaManager.CargarVidaExtra(), TiendaManager.CargarEscudo(), true, TiendaManager.CargarCasco());

        precioAntorcha.text = TiendaManager.CargarPrecioAntorcha().ToString();
        monedasTotales.text = TiendaManager.CargarCantMonedas().ToString();
    }

    public void comprarCasco()
    {
        actualizarTienda(TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarPrecioAntorcha(), TiendaManager.CargarPrecioCasco() + 10, TiendaManager.CargarIman(), TiendaManager.CargarVidaExtra(), TiendaManager.CargarEscudo(), TiendaManager.CargarAntorcha(), true);

        precioCasco.text = TiendaManager.CargarPrecioCasco().ToString();
        monedasTotales.text = TiendaManager.CargarCantMonedas().ToString();
    }

    void actualizarTienda(int precio, int precioIman, int precioVidaExtra, int precioEscudo, int PrecioAntorcha, int PrecioCasco, bool Iman, bool VidaExtra, bool Escudo, bool Antorcha, bool Casco)
    {
        TiendaManager.GuardarRecord(false, precio, precioIman, precioVidaExtra, precioEscudo, PrecioAntorcha, PrecioCasco, Iman, VidaExtra, Escudo, Antorcha, Casco);
    }
}
