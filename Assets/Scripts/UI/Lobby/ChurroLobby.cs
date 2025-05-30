using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurroLobby : MonoBehaviour
{

    //Líneas de conversación de Churro
    public GameObject[] textosChurro;
    public int lineaChurro = 0;


    public GameObject xChurro;
    public GameObject baseTexto;
    public GameObject textoChurro;
    public GameObject textoChurroFinal;
    public GameObject dialogoChurro;


    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;

    private bool puedoConversar;


    //hacer referencia al script de Relaciones para poder mencionar el nivel de Churro
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

        if (panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            puedoConversar = true;
        }
        else
        {
            puedoConversar = false;
        }



        if (xChurro.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar && textoChurro != null)
        {
            baseTexto.SetActive(true);
            textoChurro.SetActive(true);
            dialogoChurro.SetActive(true);

            xChurro.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaChurro == 0 && textoChurro.activeSelf)
        {
            panelElecciones.SetActive(true);
            elecChurro.SetActive(true);

            AudioManager.Instance.PlaySFX("Botones");
        }
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaChurro == 1 && textoChurro.activeSelf)
        {
            textoChurro.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
            lineaChurro = 2;
            dialogoChurro.SetActive(false);
            baseTexto.SetActive(false);
            Destroy(textoChurro);
        }


        if (xChurro.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar && textoChurro == null)
        {
            textoChurroFinal.SetActive(true);
            AudioManager.Instance.PlaySFX("Botones");
            dialogoChurro.SetActive(true);
            baseTexto.SetActive(true);
            xChurro.SetActive(false);
        }
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
        panelElecciones.SetActive(false);
        elecChurro.SetActive(false);

        //lineaChurro = 1;
        AvanceTextoChurro();
        AudioManager.Instance.PlaySFX("Botones");
        relaciones.CambioNivelChurro(-1);
    }

    public void Eleccion2Churro()
    {
        panelElecciones.SetActive(false);
        elecChurro.SetActive(false);

        AvanceTextoChurro();
        //lineaChurro = 1;
        AudioManager.Instance.PlaySFX("Botones");
        relaciones.CambioNivelChurro(0);
    }
}
