using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VidaJefe : MonoBehaviour
{
    public int vidaMaxima = 10;
    private int vidaActual;
    public bool estaMuerto = false;
    private bool segundaFaseActivada = false;

    public UnityEvent eventoSegundaFase;

    public bool animHerido = false;//para comprobar que la animación de herido no se esté ejecutando ya

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

        //Activa la animación de herido
        if (animHerido == false)
        {
            animHerido = true;
            this.GetComponent<Animator>().SetBool("siHerido", true);
            StartCoroutine(TiempoAnimacion());
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

    IEnumerator TiempoAnimacion() //termina la animación de herido
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Animator>().SetBool("siHerido",false);
    }
}