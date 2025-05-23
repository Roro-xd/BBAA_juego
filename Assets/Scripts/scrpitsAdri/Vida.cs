using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vidaMax = 4;
    private int vidaActual;

    public event Action OnDanoRecibido; // evento para notificar dano recibido

    bool siEsperamos = false;//variable para espera de la animación de muerte
    bool siEsperaDano = false;

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
        if (siEsperaDano == false) {
            siEsperaDano = true;
            AnimacionHerido(); //llama a un método para animar el daño
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
        if (siEsperamos == false) //comprueba que la animación de meurte solo se active una vez
        {
            StartCoroutine(TiempoEspera());
            siEsperamos = true;
            this.GetComponent<Animator>().SetBool("siMuere", true);
            Debug.Log("reproduciendo animación de muerte");
            this.GetComponent<Caminar>().sePuedeMover = false; //hace que el jugador ya no se pueda mover
        }
    }

    public int GetCurrentHealth() => vidaActual;
    public int GetMaxHealth() => vidaMax;



    //tiempo a esperar para que se vea la animación de muerte
    IEnumerator TiempoEspera()
    {

        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false); siEsperamos = false;
    }

    void AnimacionHerido() {
        if (siEsperamos == false)
        {
            this.GetComponent<Animator>().SetBool("siHerido", true);
            StartCoroutine(TiempoAnim());
         
        }
    }
    IEnumerator TiempoAnim()
    {
        yield return new WaitForSeconds(0.4f);
        this.GetComponent<Animator>().SetBool("siHerido", false);
        siEsperaDano = false;
    }
}
