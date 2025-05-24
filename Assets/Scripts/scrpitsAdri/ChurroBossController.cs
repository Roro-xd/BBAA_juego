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

        if (jugadorEnRango && Time.time > tiempoUltimoAtaque + tiempoEntreAtaques)
        {
            Atacar();
            tiempoUltimoAtaque = Time.time;
        }
    }

    void Atacar()
    {
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
            Morir(); // Ahora el método existe
        }
    }

    // Método Morir() añadido
    void Morir()
    {
        estaMuerto = true;
        animator.SetTrigger("Morir");
        Debug.Log("¡Jefe derrotado!");

        // Ejemplo de acciones al morir:
        GetComponent<Collider2D>().enabled = false; // Desactiva colisiones
        Destroy(gameObject, 2f); // Destruye el objeto después de 2 segundos
    }
}