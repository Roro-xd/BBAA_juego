using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaJefe : MonoBehaviour
{
    public int vidaMaxima = 10;
    private int vidaActual;
    private bool estaMuerto = false;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDano(int cantidad)
    {
        if (estaMuerto) return;

        vidaActual -= cantidad;
        vidaActual = Mathf.Max(vidaActual, 0);

        Debug.Log($"Jefe recibió {cantidad} de daño. Vida actual: {vidaActual}");

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        estaMuerto = true;
        Debug.Log("El jefe ha muerto.");
        // Aquí podemos meter animaciones
        gameObject.SetActive(false);
    }
}