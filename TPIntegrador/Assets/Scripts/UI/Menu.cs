using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject CanvasUI;
    public void Restart()
    {
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
}
