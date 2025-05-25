using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JugadorMonedas : MonoBehaviour
{
    public int monedas = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moneda"))
        {
            monedas++;
            Destroy(collision.gameObject);
            Debug.Log("Monedas: " + monedas);
        }
    }
}