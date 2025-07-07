using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class estadisticasUI : MonoBehaviour
{
    public GameObject estadisticas;
    public GameObject menuPrincipal;
    public TMP_Text distanciaMaxima;
    public TMP_Text maxMonedas;
    public TMP_Text partidasJugadas;
    public TMP_Text promedioDistancia;
    public TMP_Text distanciaTotal;

    public GameObject Tienda;
   

    public void irAEstadisticas()
    {
        estadisticas.SetActive(true);
        menuPrincipal.SetActive(false);

        distanciaMaxima.text = ((int)RecordManager.CargarRecord()).ToString();
        maxMonedas.text = RecordManager.CargarCantMonedas().ToString();
        partidasJugadas.text = RecordManager.CargarCantPartidas().ToString();
        promedioDistancia.text = ((int)RecordManager.CargarPromedioDistancia()).ToString();
        distanciaTotal.text = ((int)RecordManager.CargarTotalDistancia()).ToString();

        Time.timeScale = 0f;
    }


    public void volverDeEstadisticas()
    {
        estadisticas.SetActive(false);
        menuPrincipal.SetActive(true);
        Time.timeScale = 1f;
    }

    public void AbrirTienda()
    {
        menuPrincipal.SetActive(false);
        Tienda.SetActive(true);
    }
    public void volverDeTienda()
    {
        Tienda.SetActive(false);
        menuPrincipal.SetActive(true);
        Time.timeScale = 1f;
    }

}
