using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurroLobby : MonoBehaviour
{
    public GameObject xChurro;
    public GameObject baseTexto;
    public GameObject textoChurro;
    public GameObject dialogoChurro;


    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;

    private bool puedoConversar;



    void Start()
    {
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
            baseTexto.SetActive(true);
            textoChurro.SetActive(true);
            dialogoChurro.SetActive(true);

            xChurro.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        else if (textoChurro.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(false);
            textoChurro.SetActive(false);
            dialogoChurro.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
        }

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
}
