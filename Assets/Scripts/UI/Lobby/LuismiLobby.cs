using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuismiLobby : MonoBehaviour
{
    //Identificación X (inicio conver)
    public GameObject xLuismi;

    //Conver visual (cuadro, texto y demás)
    public GameObject baseTexto;
    public GameObject textoLuismi;
    public GameObject dialogoNadie; //Para los personajes que no son principales


    //Mencionar paneles del menú para que no se pueda alterar la conver si se está en pausa
    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;


    //Resumir en una bool si el menú está abierto o no
    private bool puedoConversar;



    void Start()
    {
        xLuismi.SetActive(false);
    }

    void Update()
    {

        //Comprobación de la bool del menú
        if (panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            puedoConversar = true;
        }
        else
        {
            puedoConversar = false;
        }


        //Si puedo iniciar la conver y la inicio (pulsar X)
        if (xLuismi.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(true);
            textoLuismi.SetActive(true);
            dialogoNadie.SetActive(true);

            Debug.Log("X se ha ocultado");
            xLuismi.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        //Continuar la conver (en este caso, acabarla)
        else if (textoLuismi.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(false);
            textoLuismi.SetActive(false);
            dialogoNadie.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
        }

    }


    //La X sobre el personaje me indica que puedo iniciar la conver
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xLuismi.SetActive(true);
            Debug.Log("La X está activa");
        }
    }


    //Si salgo de su rango, no puedo conversar
    void OnTriggerExit2D(Collider2D col)
    {
        xLuismi.SetActive(false);
        Debug.Log("La X se ha desactivado");
    }
}
