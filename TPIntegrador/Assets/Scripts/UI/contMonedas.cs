using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class contMonedas : MonoBehaviour
{
    public TMP_Text monedasTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        monedasTxt.text = movimiento.instancia.contadorMonedas.ToString() + "x";
    }
}
