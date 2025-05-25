using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class JugadorMonedas : MonoBehaviour
{
    public int monedas = 0;
    public GameObject conteoMonedas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moneda"))
        {
            monedas++;
            Destroy(collision.gameObject);
            Debug.Log("Monedas: " + monedas);
        }
    }

    void Update()
    {
        conteoMonedas.GetComponent<TextMeshProUGUI>().text = monedas.ToString();
    }
}