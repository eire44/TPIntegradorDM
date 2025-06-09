using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirMenu : MonoBehaviour
{
    public GameObject CanvasMenu;

    public void abrirMenu()
    {
        Time.timeScale = 0f;
        CanvasMenu.SetActive(true);
    }
}
