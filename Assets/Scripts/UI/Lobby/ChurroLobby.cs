using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurroLobby : MonoBehaviour
{

    //Líneas de conversación de Churro
    public GameObject[] textosChurro;
    public int lineaChurro = 0;


    //Conver visual (cuadro, texto y demás)
    public GameObject xChurro;
    public GameObject baseTexto;
    public GameObject textoChurro;
    public GameObject textoChurroFinal;
    public GameObject dialogoChurro;


    //Mencionar paneles del menú para que no se pueda alterar la conver si se está en pausa
    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;


    //Resumir en una bool si el menú está abierto o no
    private bool puedoConversar;


    //Hacer referencia al script de Relaciones para poder mencionar el nivel de Churro
    public GameObject panelElecciones;
    public GameObject elecChurro;
    public GameObject bun;
    private Relaciones relaciones;



    void Start()
    {
        textoChurro.SetActive(false);
        xChurro.SetActive(false);

        relaciones = bun.GetComponent<Relaciones>();
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


        //Si puedo iniciar la conver y la inicio (pulsar X) --- primera conver
        if (xChurro.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar && textoChurro != null)
        {
            baseTexto.SetActive(true);
            textoChurro.SetActive(true);
            dialogoChurro.SetActive(true);

            xChurro.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        //Aparición de elecciones
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaChurro == 0 && textoChurro.activeSelf)
        {
            panelElecciones.SetActive(true);
            elecChurro.SetActive(true);

            AudioManager.Instance.PlaySFX("Botones");
        }
        //Cerrar y destruir primera conver al acabarla
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaChurro == 1 && textoChurro.activeSelf)
        {
            textoChurro.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
            lineaChurro = 2;
            dialogoChurro.SetActive(false);
            baseTexto.SetActive(false);
            Destroy(textoChurro);
        }

        //Inicio segunda conver
        if (xChurro.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar && textoChurro == null)
        {
            textoChurroFinal.SetActive(true);
            AudioManager.Instance.PlaySFX("Botones");
            dialogoChurro.SetActive(true);
            baseTexto.SetActive(true);
            xChurro.SetActive(false);
        }
        //Cerrar segunda conver
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaChurro == 2 && textoChurroFinal.activeSelf)
        {
            textoChurroFinal.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
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


    //La X sobre el personaje me indica que puedo iniciar la conver
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xChurro.SetActive(true);
        }
    }


    //Si salgo de su rango, no puedo conversar
    void OnTriggerExit2D(Collider2D col)
    {
        xChurro.SetActive(false);
    }


    //PRIMERA ELECCIÓN (relacionado con botón correspondiente) --- diminución nivel en 2
    public void Eleccion1Churro()
    {
        panelElecciones.SetActive(false);
        elecChurro.SetActive(false);

        AvanceTextoChurro();
        AudioManager.Instance.PlaySFX("Error");
        relaciones.CambioNivelChurro(-2);
    }


    //SEGUNDA ELECCIÓN (relacionado con botón correspondiente) --- diminución nivel en 1    
    public void Eleccion2Churro()
    {
        panelElecciones.SetActive(false);
        elecChurro.SetActive(false);

        AvanceTextoChurro();
        AudioManager.Instance.PlaySFX("Error");
        relaciones.CambioNivelChurro(-1);
    }
}
