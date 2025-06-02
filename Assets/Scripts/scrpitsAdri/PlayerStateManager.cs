using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateManager : MonoBehaviour
{
    public bool puedeMoverse = true;
    public bool puedeAtacar = true;

     public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;

    private bool menuAbierto;


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
        if (SceneManager.GetActiveScene().name == "LobbyInteractuable")
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
        if(menuAbierto)

        {
            puedeMoverse = false;
            puedeAtacar = false;
        }
        else 

            puedeMoverse = true;
            puedeAtacar = true;

        // Aplicar los estados a los scripts
        if (jugadorMovimiento != null)
            jugadorMovimiento.sePuedeMover = puedeMoverse;


        if (jugadorAtaque != null)
            jugadorAtaque.siPuedoAtacar = puedeAtacar;
            
        
        if (panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            menuAbierto = false;
        }
        else
        {
            menuAbierto = true;
        }





    }
}


