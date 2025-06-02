using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class JugadorMonedas : MonoBehaviour
{
    public int monedas = 0;
    private GameObject conteoMonedas;


    void Start()
    {
        if (Vida.Instance != null)
        {
            Vida.Instance.monedas = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moneda"))
        {
            AudioManager.Instance.PlaySFX("dineroRecoger");
            Vida.Instance.monedas++;
            Destroy(collision.gameObject);
            Debug.Log("Monedas: " + Vida.Instance.monedas);
        }
    }

    void Update()
    {
        conteoMonedas = GameObject.Find("Conteo_dinero");
        conteoMonedas.GetComponent<TextMeshProUGUI>().text = Vida.Instance.monedas.ToString();
    }


    public void CambioMonedas(int cambio)
    {
        Vida.Instance.monedas += cambio;
    }
}