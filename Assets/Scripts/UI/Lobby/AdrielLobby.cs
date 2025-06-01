using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrielLobby : MonoBehaviour
{
    //Identificación X (inicio conver)
    public GameObject xAdriel;

    //Conver visual (cuadro, texto y demás)
    public GameObject baseTexto;
    public GameObject textoAdriel;
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
        xAdriel.SetActive(false);
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
        if (xAdriel.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(true);
            textoAdriel.SetActive(true);
            dialogoNadie.SetActive(true);

            xAdriel.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        //Continuar la conver (en este caso, acabarla)
        else if (textoAdriel.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(false);
            textoAdriel.SetActive(false);
            dialogoNadie.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
        }

    }


    //La X sobre el personaje me indica que puedo iniciar la conver
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xAdriel.SetActive(true);
        }
    }
    

    //Si salgo de su rango, no puedo conversar
    void OnTriggerExit2D(Collider2D col)
    {
        xAdriel.SetActive(false);
    }

}
