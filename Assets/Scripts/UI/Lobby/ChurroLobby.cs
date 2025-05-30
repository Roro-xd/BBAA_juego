using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurroLobby : MonoBehaviour
{

    //Líneas de conversación de Churro
    public GameObject[] textosChurro;
    public int lineaChurro = 1;


    public GameObject xChurro;
    public GameObject baseTexto;
    public GameObject textoChurro; //Probablemente no haga falta luego
    public GameObject dialogoChurro;


    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;

    private bool puedoConversar;


    //hacer referencia al script de Relaciones para poder mencionar el nivel de Churro



    void Start()
    {
        textosChurro[lineaChurro].SetActive(false);
        xChurro.SetActive(false);
    }

    void Update()
    {

        if (panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            puedoConversar = true;
        }
        else
        {
            puedoConversar = false;
        }



        if (xChurro.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            //AvanceTextoYori();
            baseTexto.SetActive(true);
            textosChurro[lineaChurro].SetActive(true);
            dialogoChurro.SetActive(true);

            xChurro.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaChurro == 0)
        {
            //APARICION DE PANEL/IMAGEN+BOTONES PARA ESCOGER

            AudioManager.Instance.PlaySFX("Botones");
        }
        /*else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaChurro == 1)
        {
            AvanceTextoChurro();
            baseTexto.SetActive(false);
            textosChurro[lineaChurro].SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
        }*/
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && (lineaChurro == 1 || lineaChurro == 2))
        {
            textosChurro[lineaChurro].SetActive(false);
            lineaChurro = 3;
            dialogoChurro.SetActive(false);
            baseTexto.SetActive(false);
        }
    }



    public void AvanceTextoChurro()
    {
        textosChurro[lineaChurro].SetActive(false);
        lineaChurro = (lineaChurro + 1) % textosChurro.Length;
        textosChurro[lineaChurro].SetActive(true);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xChurro.SetActive(true);
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        xChurro.SetActive(false);
    }

    public void Eleccion1Churro()
    {
        //cerrar panel de elección

        lineaChurro = 1;
        //Establecer puntuación
        //relaciones.nivelChurro -= 1;
    }

    public void Eleccion2Churro()
    {
        //cerrar panel de elección

        lineaChurro = 1;
        //Establecer puntuación
        //relaciones.nivelChurro += 0;
    }
}
