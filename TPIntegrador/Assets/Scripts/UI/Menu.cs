using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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

    private void Awake()
    {
        instancia = this;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
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

        gameOverUI.GetComponentInChildren<TMP_Text>().text = ((int)distancia.instancia.distanciaRecorrida).ToString();
        Time.timeScale = 0f;
    }
}
