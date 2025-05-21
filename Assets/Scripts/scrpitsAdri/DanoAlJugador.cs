using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoAlJugador : MonoBehaviour
{
    public int dano = 1;
    public float tiempoEntreDanos = 1f;

    private float tiempoSiguienteDano = 0f;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= tiempoSiguienteDano)
            {
                Vida vidaJugador = collision.gameObject.GetComponent<Vida>();
                if (vidaJugador != null)
                {
                    vidaJugador.RecibeDano(dano);
                    tiempoSiguienteDano = Time.time + tiempoEntreDanos;
                }
            }
        }
    }
}