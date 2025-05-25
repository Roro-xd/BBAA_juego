using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaJefe : MonoBehaviour
{
    public int vidaMaxima = 10;
    private int vidaActual;
    private bool estaMuerto = false;
    private bool segundaFaseActivada = false;

    public UnityEvent eventoSegundaFase;

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

        // Activa la segunda fase al 50%
        if (!segundaFaseActivada && vidaActual <= vidaMaxima / 2)
        {
            segundaFaseActivada = true;
            Debug.Log("¡Segunda fase activada!");
            eventoSegundaFase.Invoke(); // Dispara la segunda fase
        }

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        estaMuerto = true;
        Debug.Log("El jefe ha muerto.");
        gameObject.SetActive(false);
    }
}