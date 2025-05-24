using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurroBossController : MonoBehaviour
{
    public float vidaMaxima = 100f;
    private float vidaActual;

    public float rangoDeteccion = 10f;
    public float tiempoEntreAtaques = 2f;
    private float tiempoUltimoAtaque;

    public Transform jugador;
    public Animator animator;

    private bool jugadorEnRango = false;
    private bool estaMuerto = false;

    void Start()
    {
        vidaActual = vidaMaxima;
        if (jugador == null)
        {
            jugador = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (estaMuerto) return;

        float distancia = Vector2.Distance(transform.position, jugador.position);
        jugadorEnRango = distancia < rangoDeteccion;

       // animator.SetBool("JugadorEnRango", jugadorEnRango);
        //aun no pongo animaciones
        if (jugadorEnRango && Time.time > tiempoUltimoAtaque + tiempoEntreAtaques)
        {
            Atacar();
            tiempoUltimoAtaque = Time.time;
        }
    }

    void Atacar()
    {
        // Esto es un Place Holder, no funciona
        animator.SetTrigger("Ataca");
        Debug.Log("El jefe ataca!");
    }

    public void RecibirDanio(float dano)
    {
        if (estaMuerto) return;

        vidaActual -= dano;
        animator.SetTrigger("Herido");

        if (vidaActual <= 0)
        {
            Morir();
        }
    }
}