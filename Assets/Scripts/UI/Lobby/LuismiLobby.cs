using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuismiLobby : MonoBehaviour
{
    public GameObject xLuismi;
    public GameObject baseTexto;
    public GameObject textoLuismi;
    public GameObject dialogoNadie;


    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;

    private bool puedoConversar;



    void Start()
    {
        xLuismi.SetActive(false);
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



        if (xLuismi.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(true);
            textoLuismi.SetActive(true);
            dialogoNadie.SetActive(true);

            xLuismi.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        else if (textoLuismi.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(false);
            textoLuismi.SetActive(false);
            dialogoNadie.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xLuismi.SetActive(true);
        }
    }
    

    void OnTriggerExit2D(Collider2D col)
    {
        xLuismi.SetActive(false);
    }
}
