using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_inicio : MonoBehaviour
{

    GameObject panelInicio;
    GameObject panelAjustes;
    GameObject panelExtras;
    GameObject panelCreditos;


    void Start()
    {
        panelInicio = GameObject.Find("Panel_inicio");
        
        panelAjustes = GameObject.Find("Panel_ajustes");
        panelAjustes.SetActive(false);

        panelExtras = GameObject.Find("Panel_extras");
        panelExtras.SetActive(false);

        panelCreditos = GameObject.Find("Panel_creditos");
        panelCreditos.SetActive(false);
    }

   
    void Update()
    {
        
    }


    //Para los botones de la pantalla de inicio
    public void botonInicioSalir() {
        Application.Quit();
    }


    public void botonInicioJugar() {
        SceneManager.LoadScene("Lobby"); //CAMBIAR A NOMBRE QUE VAYA A TENER AL FINAL
    }

    
    public void botonInicioAjustes() {
        panelAjustes.SetActive(true);
    }


    public void botonInicioCreditos() {
        panelCreditos.SetActive(true);
    }


    //Para los botones de la pantalla de ajustes

        //PONER LAS COSAS DEL VOLUMEN
        
        //Para los botones de la pantalla de extras
        public void botonAjustesExtras() {
            panelExtras.SetActive(true);
        }

        public void botonExtrasVolver() {
            panelExtras.SetActive(false);
        }

    public void botonAjustesCreditosVolver() {
        /*if (panelAjustes.SetActive(true) == true) {
            panelAjustes.SetActive(false);
        };

        if (panelCreditos.SetActive(true) == true) {}
            panelCreditos.SetActive(false);
        };*/
        panelAjustes.SetActive(false);
        panelCreditos.SetActive(false);
    }


    //AÑADIR SONIDOS DE LOS BOTONES


}
