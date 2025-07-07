using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instancia;
    public GameObject CanvasUI;
    public GameObject gameOverUI;
    public GameObject UiPrincipal;
    public GameObject UIpausa;
    public TMP_Text distanciaActual;
    public TMP_Text distanciaRecord;

    private void Awake()
    {
        instancia = this;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        if(UIpausa.activeInHierarchy)
        {
            RecordManager.GuardarRecord(distancia.instancia.distanciaRecorrida, movimiento.instancia.contadorMonedas);
            TiendaManager.GuardarRecord(true, movimiento.instancia.contadorMonedas, TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarIman(), TiendaManager.CargarVidaExtra(), TiendaManager.CargarEscudo());
        }
        
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Continuar()
    {
        CanvasUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void VolverAlMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void gameOver()
    {
        UiPrincipal.SetActive(false);
        gameOverUI.SetActive(true);

        distanciaActual.text = ((int)distancia.instancia.distanciaRecorrida).ToString();

        RecordManager.GuardarRecord(distancia.instancia.distanciaRecorrida, movimiento.instancia.contadorMonedas);
        TiendaManager.GuardarRecord(true, movimiento.instancia.contadorMonedas, TiendaManager.CargarPrecioIman(), TiendaManager.CargarPrecioVidaExtra(), TiendaManager.CargarPrecioEscudo(), TiendaManager.CargarIman(), TiendaManager.CargarVidaExtra(), TiendaManager.CargarEscudo());
        float record = RecordManager.CargarRecord();
        distanciaRecord.text = "Record Distance: " + (int)record;
        Time.timeScale = 0f;
    }
}
