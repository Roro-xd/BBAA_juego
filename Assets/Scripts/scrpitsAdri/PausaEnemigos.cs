using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*********************************************/
/*********************************************/
/*********************************************/
/***************DEPRECATED*************/
/*********************************************/
/*********************************************/
/*********************************************/



public class PausaEnemigos : MonoBehaviour
{
    public bool puedeMoverse = true;

    private GameObject panelMenu;
    private GameObject panelSeguro;
    private GameObject panelVolumen;
    private GameObject panelControles;
    private bool menuAbierto;
    private EnemyController enemigoMovimiento;

    void Start()
    {
        panelMenu = GameObject.Find("Panel_menu");

        panelSeguro = GameObject.Find("Panel_seguro");

        panelVolumen = GameObject.Find("Panel_volumen");

        panelControles = GameObject.Find("Panel_controles");

        enemigoMovimiento = GetComponent<EnemyController>();

    }

    void Update()
    {
        if (menuAbierto)

        {
            puedeMoverse = false;

        }
        else

            puedeMoverse = true;

        // Aplicar los estados a los scripts
        if (enemigoMovimiento != null)
            enemigoMovimiento.isChasing = puedeMoverse;


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

