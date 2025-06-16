using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movEscenario : MonoBehaviour
{
    public static movEscenario instancia;
    public float velocidad = 15f;
    public List<Transform> obstaculosLista = new List<Transform>();
    private void Awake()
    {
        instancia = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destruirObstaculo();
    }

    void destruirObstaculo()
    {
        for (int i = 0; i < obstaculosLista.Count; i++)
        {
            Transform obstaculo = obstaculosLista[i];
            if (obstaculo != null && (!obstaculo.name.Contains("Trap")))
            {
                obstaculo.position += new Vector3(0, 0, -1) * velocidad * Time.deltaTime;

                if (obstaculo.position.z < -15f)
                {
                    Destroy(obstaculo.gameObject);
                    obstaculosLista.Remove(obstaculo);
                    i--;
                }
            }
        }
    }
}
