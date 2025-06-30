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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void irAEstadisticas()
    {
        estadisticas.SetActive(true);
        menuPrincipal.SetActive(false);

        distanciaMaxima.text = RecordManager.CargarRecord().ToString();
        maxMonedas.text = RecordManager.CargarCantMonedas().ToString();
        partidasJugadas.text = RecordManager.CargarCantPartidas().ToString();
        promedioDistancia.text = RecordManager.CargarPromedioDistancia().ToString();
        distanciaTotal.text = RecordManager.CargarTotalDistancia().ToString();

        Time.timeScale = 0f;
    }


    public void volverDeEstadisticas()
    {
        estadisticas.SetActive(false);
        menuPrincipal.SetActive(true);
        Time.timeScale = 1f;
    }
}
