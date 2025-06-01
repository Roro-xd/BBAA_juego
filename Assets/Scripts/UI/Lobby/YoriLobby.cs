using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoriLobby : MonoBehaviour
{
    //Animación Idle
    private Animator yoriAnim;
    public GameObject yori;


    //Líneas de conversación de Yori
    public GameObject[] textosYori;
    public int lineaYori = 1;


    //Conver visual (cuadro, texto y demás)
    public GameObject xYori;
    public GameObject baseTexto;
    public GameObject textoYori;
    public GameObject dialogoYori;


    //Mencionar paneles del menú para que no se pueda alterar la conver si se está en pausa
    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;


    //Resumir en una bool si el menú está abierto o no
    private bool puedoConversar;



    void Start()
    {
        //Establzco animacion Idle
        yoriAnim = yori.GetComponent<Animator>();
        yoriAnim.SetBool("YoriIdle", true);
        yoriAnim.SetBool("YoriParado", false);

        textoYori.SetActive(false);
        xYori.SetActive(false);
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
        if (xYori.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            baseTexto.SetActive(true);
            textoYori.SetActive(true);
            dialogoYori.SetActive(true);

            xYori.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        //Avance de la conver
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaYori == 0 && textoYori.activeSelf)
        {
            AvanceTextoYori();
            dialogoYori.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        //Cerrar y reiniciar la conver
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaYori == 1 && textoYori.activeSelf)
        {
            AvanceTextoYori();
            baseTexto.SetActive(false);
            textoYori.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
        }
    }



    public void AvanceTextoYori()
    {
        textosYori[lineaYori].SetActive(false);
        lineaYori = (lineaYori + 1) % textosYori.Length;
        textosYori[lineaYori].SetActive(true);
    }
    

    //La X sobre el personaje me indica que puedo iniciar la conver
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xYori.SetActive(true);
        }
    }
    

    //Si salgo de su rango, no puedo conversar
    void OnTriggerExit2D(Collider2D col)
    {
        xYori.SetActive(false);
    }
}
