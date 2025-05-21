using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vidaMax = 4;
    private int vidaActual;

    public event Action OnDanoRecibido; // evento para notificar dano recibido

    void Start()
    {
        vidaActual = vidaMax;
    }

    public void RecibeDano(int cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);

        Debug.Log("Vida actual: " + vidaActual);

        OnDanoRecibido?.Invoke(); // aviso que se recibio dano

        if (vidaActual <= 0)
        {
            Muerte();
        }
    }

    public void Curar(int cantidad)
    {
        vidaActual += cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);

        Debug.Log("Curado. Vida actual: " + vidaActual);
    }

    public void AumentoVidaMax(int cantidad, bool curarFull = true)
    {
        vidaMax += cantidad;
        if (curarFull)
            vidaActual = vidaMax;

        Debug.Log("Nueva vida maxima: " + vidaMax + " | Vida actual: " + vidaActual);
    }

    private void Muerte()
    {
        Debug.Log("El jugador ha muerto.");
        gameObject.SetActive(false);
    }

    public int GetCurrentHealth() => vidaActual;
    public int GetMaxHealth() => vidaMax;
}
