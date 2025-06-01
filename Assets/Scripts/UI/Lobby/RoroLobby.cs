using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoroLobby : MonoBehaviour
{
    //Identificación X (inicio conver)
    public GameObject xRoro;

    //Conver visual (cuadro, texto y demás)
    public GameObject baseTexto;
    public GameObject textoRoro;
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
        xRoro.SetActive(false);
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
        if (xRoro.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(true);
            textoRoro.SetActive(true);
            dialogoNadie.SetActive(true);

            Debug.Log("X se ha ocultado");
            xRoro.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        //Continuar la conver (en este caso, acabarla)
        else if (textoRoro.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(false);
            textoRoro.SetActive(false);
            dialogoNadie.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
        }

    }


    //La X sobre el personaje me indica que puedo iniciar la conver
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xRoro.SetActive(true);
        }
    }
    

    //Si salgo de su rango, no puedo conversar
    void OnTriggerExit2D(Collider2D col)
    {
        xRoro.SetActive(false);
    }

}
