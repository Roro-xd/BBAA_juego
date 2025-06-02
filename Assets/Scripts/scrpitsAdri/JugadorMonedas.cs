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
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moneda"))
        {
            AudioManager.Instance.PlaySFX("dineroRecoger");
            monedas++;
            Destroy(collision.gameObject);
            Debug.Log("Monedas: " + monedas);
        }
    }

    void Update()
    {
        conteoMonedas = GameObject.Find("Conteo_dinero");
        conteoMonedas.GetComponent<TextMeshProUGUI>().text = monedas.ToString();
    }


    public void CambioMonedas(int cambio)
    {
        monedas += cambio;
    }
}