using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidoLuchadora : MonoBehaviour
{

    private int vida;

    void Start()
    {
        vida = this.GetComponent<VidaEnemigo>().vidaActual;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida > 0)
        {
            AudioManager.Instance.PlayOtros("roroFlota");
        }

    }
}
