using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class casco : MonoBehaviour
{
    public GameObject pantallaUI;
    public Button cascoBtn;
    public GameObject cascoActivado;

    
    void Update()
    {
        if (TiendaManager.CargarCasco() && pantallaUI.activeInHierarchy)
        {
            cascoBtn.enabled = true;
            ColorBlock colors = cascoBtn.colors;
            colors.normalColor = new Color(1, 1, 1, 1);
            cascoBtn.colors = colors;
        }
        else
        {
            cascoBtn.enabled = false;
            ColorBlock colors = cascoBtn.colors;
            colors.normalColor = new Color(0.7f, 0.7f, 0.7f, 0.5f);
            cascoBtn.colors = colors;
        }
    }


    public void activarCasco()
    {
        cascoActivado.SetActive(true);
    }
}
