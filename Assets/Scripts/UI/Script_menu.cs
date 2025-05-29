using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_menu : MonoBehaviour
{

    //Control de los paneles
    GameObject panelMenu;
    GameObject panelSeguro;
    GameObject panelVolumen;
    GameObject panelControles;


    //PROBLEMAS CON BOTONES --- SOLUCION: interactividad con teclado
    /*public GameObject[] botonesMenu;
    public int bMenuSelect = 0;
    public GameObject[] botonesSeguro;
    public int bSeguroSelect = 0;*/


    void Start()
    {

        panelMenu = GameObject.Find("Panel_menu");
        panelMenu.SetActive(false); 

        panelSeguro = GameObject.Find("Panel_seguro");
        panelSeguro.SetActive(false);

        panelVolumen = GameObject.Find("Panel_volumen");
        panelVolumen.SetActive(false);

        panelControles = GameObject.Find("Panel_controles");
        panelControles.SetActive(false);

    }

    void Update()
    {
        //Activar menú con Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
            {
                panelMenu.SetActive(true);
                AudioManager.Instance.PlaySFX("Botones");
            }
        }


        //En caso de que esté abierta la primera pantalla del menú
        /*if (panelMenu.activeSelf && panelSeguro.activeSelf == false && panelControles.activeSelf == false && panelVolumen.activeSelf == false)
        {
            //Interacción de avance con los "botones" del menú
           if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                RetrasoBotonMenu();
            }
            

            //Interacción de retroceso con los "botones" del menú
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                AvanceBotonMenu();
            }


            //Interacción con cada "botón" del menú
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (bMenuSelect == 2 && panelSeguro.activeSelf == false) //CONTINUAR
                {
                    panelControles.SetActive(true);
                    panelMenu.SetActive(false);
                    SuenaBoton();
                }
                else if (bMenuSelect == 1 && panelSeguro.activeSelf == false) //VOLUMEN
                {
                    panelVolumen.SetActive(true);
                    panelMenu.SetActive(false);
                    SuenaBoton();
                }
                else if (bMenuSelect == 3) //CONTROLES
                {
                    panelSeguro.SetActive(true);
                    SuenaBoton();
                }
                else if (bMenuSelect == 0) //SALIR PARTIDA
                {
                    panelMenu.SetActive(false);
                    SuenaVolver();
                }
            }

        }*/


        //Para activar/desactivar los recuadros que indican la selección
        /*if (panelMenu.activeSelf == false)
        {
            botonesMenu[bMenuSelect].SetActive(false);
        }
        else
        {
            botonesMenu[bMenuSelect].SetActive(true);
        }

        if (panelSeguro.activeSelf == false)
        {
            botonesSeguro[bSeguroSelect].SetActive(false);
        }
        else
        { 
           botonesSeguro[bSeguroSelect].SetActive(true); 
        }*/



        //Interactividad dentro de panel de Seguro (al intentar salir de la partida)
        /*if (panelSeguro.activeSelf)
        {
            //Interacción de avance con los "botones"
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                RetrasoBotonSeguro();
            }

            //Interacción de retroceso con los "botones"
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AvanceBotonSeguro();
            }

            //Interacción con cada "botón"
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (bSeguroSelect == 0) //QUERER CONTINUAR JUGANDO
                {
                    panelSeguro.SetActive(false);
                    panelMenu.SetActive(true);
                    SuenaVolver();
                }

                if (bSeguroSelect == 1) //QUERER ABANDONAR LA PARTIDA
                {
                    SceneManager.LoadScene("Inicio");
                }
            }
        }*/


        //Para salir del menú de controles
       /*if (panelControles.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            panelControles.SetActive(false);
            panelMenu.SetActive(true);
            SuenaVolver();
        }

        //Para salir del menú de volumen
        if (panelVolumen.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            panelVolumen.SetActive(false);
            panelMenu.SetActive(true);
            SuenaVolver();
        }*/

    }

    //Interacción con indicadores de MENÚ y SEGURO
    /*public void AvanceBotonMenu()
    {
        botonesMenu[bMenuSelect].SetActive(false);
        bMenuSelect = (bMenuSelect + 1) % botonesMenu.Length;
        botonesMenu[bMenuSelect].SetActive(true);
    }

    public void RetrasoBotonMenu()
    {
        botonesMenu[bMenuSelect].SetActive(false);
        bMenuSelect--;
        if (bMenuSelect < 0)
        {
            bMenuSelect += botonesMenu.Length;
        }

        botonesMenu[bMenuSelect].SetActive(true);
    }


     public void AvanceBotonSeguro()
    {
        botonesSeguro[bSeguroSelect].SetActive(false);
        bSeguroSelect = (bSeguroSelect + 1) % botonesSeguro.Length;
        botonesSeguro[bSeguroSelect].SetActive(true);
    }

    public void RetrasoBotonSeguro()
    {
        botonesSeguro[bSeguroSelect].SetActive(false);
        bSeguroSelect--;
        if (bSeguroSelect < 0)
        {
            bSeguroSelect += botonesSeguro.Length;
        }

        botonesSeguro[bSeguroSelect].SetActive(true);
    }*/






    //INTERACCIÓNES INICIALES CON LOS BOTONES (que por algún motivo no funcionan)
    public void AbrirVol()
    {
        panelVolumen.SetActive(true);
        panelMenu.SetActive(false);

    }

    public void CerrarVol()
    {
        panelVolumen.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void AbriControles()
    {
        panelControles.SetActive(true);
        panelMenu.SetActive(false);
    }

    public void CerrarControles()
    {
        panelControles.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void SalirJuego()
    {
        panelSeguro.SetActive(true);
    }

    public void ContinuarJuego()
    {
        Debug.Log("Continuar");
        panelMenu.SetActive(false);
        
    }

    public void SiQuiero()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void NoQuiero()
    {
        panelSeguro.SetActive(false);
    }
    

    //Respecto a sonidos
    public void SuenaBoton()
    {
        AudioManager.Instance.PlaySFX("Botones");
    }

    public void SuenaVolver()
    {
        AudioManager.Instance.PlaySFX("Volver");

    }
}
