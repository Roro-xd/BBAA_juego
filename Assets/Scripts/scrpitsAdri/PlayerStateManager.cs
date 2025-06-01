using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateManager : MonoBehaviour
{
    public bool puedeMoverse = true;
    public bool puedeAtacar = true;

    public GameObject menu;

    private Caminar jugadorMovimiento;
    private AtaqueMelee jugadorAtaque;

    void Start()
    {
        jugadorMovimiento = GetComponent<Caminar>();
        jugadorAtaque = GetComponent<AtaqueMelee>();
    }

    void Update()
    {
        // Ejemplo: en escenas llamadas "Lobby" no puede atacar pero sí moverse
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            puedeMoverse = true;
            puedeAtacar = false;
        }
        else
        {
            puedeMoverse = true;
            puedeAtacar = true;
        }

        // Si el menú está activo, no puede ni moverse ni atacar
        if (menu != null && menu.activeSelf)
        {
            puedeMoverse = false;
            puedeAtacar = false;
        }

        // Aplicar los estados a los scripts
        if (jugadorMovimiento != null)
            jugadorMovimiento.sePuedeMover = puedeMoverse;


        if (jugadorAtaque != null)
    jugadorAtaque.sePuedeAtacar = puedeAtacar;

    }
}
