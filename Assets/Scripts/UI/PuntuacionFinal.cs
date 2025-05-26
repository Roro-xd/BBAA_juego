using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PuntuacionFinal : MonoBehaviour
{

    //Este script va en el obj texto donde vaya a ir el valor
    string puntuacionFinal;

    public int vidaActual;
    public int dano;
    public int dinero;

    public GameObject stats;

    private GameObject panelPunt;

    public GameObject churro;
    private bool churroMuerto;

    void Start()
    {
        stats.GetComponent<Stats_contador>().vidaActual = vidaActual;
        stats.GetComponent<Stats_contador>().dineroActual = dinero;
        stats.GetComponent<Stats_contador>().dano = dano;

        panelPunt = GameObject.Find("Panel_Puntuacion");
        panelPunt.SetActive(false);

        churroMuerto = churro.GetComponent<VidaJefe>().estaMuerto;
    }


    void Update()
    {
        //String e int no pueden ir juntos; creo una variable para obtener el dato de la puntuación
        int punt = (vidaActual * 10) +
        (dinero * 10) +
        (dano * 10);

        //Transformo el dato int en string (con el nombre antes establecido)
        puntuacionFinal = punt.ToString();

        //Modifico el texto UI que hay en el archivo
        this.GetComponent<TextMeshProUGUI>().text = puntuacionFinal;

        if (churroMuerto)
        {
            StartCoroutine(TiempoPuntuacion());
        }

        if (panelPunt.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                BotonContinuar();
            }
        }
    }



    IEnumerator TiempoPuntuacion() //Hasta que salga la puntuación
    {
        yield return new WaitForSeconds(1.5f);
        panelPunt.SetActive(false);
    }


    public void BotonContinuar()
    {
        SceneManager.LoadScene("Victoria");
    }
}
