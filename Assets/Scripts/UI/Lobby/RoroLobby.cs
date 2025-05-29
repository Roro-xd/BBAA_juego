using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoroLobby : MonoBehaviour
{

    public GameObject xRoro;
    public GameObject baseTexto;
    public GameObject textoRoro;
    public GameObject dialogoNadie;


    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;

    private bool puedoConversar;



    void Start()
    {
        xRoro.SetActive(false);
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



        if (xRoro.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(true);
            textoRoro.SetActive(true);
            dialogoNadie.SetActive(true);

            xRoro.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        else if (textoRoro.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(false);
            textoRoro.SetActive(false);
            dialogoNadie.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xRoro.SetActive(true);
        }
    }
    

    void OnTriggerExit2D(Collider2D col)
    {
        xRoro.SetActive(false);
    }

}
