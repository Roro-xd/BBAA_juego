using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Script_victoria : MonoBehaviour
{

    //Para animar a los personajes
    private GameObject churro;
    private Animator animChurro;

    private GameObject napo;
    private Animator animNapo;

    private GameObject yori;
    private Animator animYori;


    //Organización del diálogo + elementos que intervienen (X, Z, cuadro texto, etc.)
    public GameObject[] dialogo;
    public int lineaDialogo = 0;
    public GameObject zRegresa;
    public GameObject xAvanza;
    public GameObject cuadrotexto;


    //Panel el negro para que no se produzca un cambio brusco de escena + FINAL
    public GameObject panelN;
    private Animator animPanelN;
    public GameObject botonSalir;
    public GameObject gracias;


    //Referencia al menú para que no se pueda avanzar el diálogo si se está en pausa
    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;



    void Start()
    {
        churro = GameObject.Find("Churro");
        animChurro = churro.GetComponent<Animator>();

        napo = GameObject.Find("Napo");
        animNapo = napo.GetComponent<Animator>();

        yori = GameObject.Find("Yorique");
        animYori = yori.GetComponent<Animator>();

        panelN = GameObject.Find("Panel_Negro");
        animPanelN = panelN.GetComponent<Animator>();



        animChurro.SetBool("ChurroCaminaVIC", true);
        animChurro.SetBool("ChurroParado", false);
        StartCoroutine("ChurroAIdle");


        zRegresa.SetActive(false);
        xAvanza.SetActive(false);
        cuadrotexto.SetActive(false);
        //Aparición texto al inicio, tras un rato
        StartCoroutine("ApareceTexto");

    }



    void Update()
    {
        //No poder regresar el diálogo si es la primera línea
        if (lineaDialogo == 0)
        {
            zRegresa.SetActive(false);
        }
        //Anim Napo y Yori
        else if (lineaDialogo == 3)
        {
            animNapo.SetBool("NapoVICCamina", true);
            animNapo.SetBool("NapoParada", false);
            animYori.SetBool("YoriParado", false);
            animYori.SetBool("Yor_VIC_Caminado", true);
        }
        //Final diálogo
        else if (lineaDialogo == 6)
        {
            zRegresa.SetActive(false);
            xAvanza.SetActive(false);
        }
        //Posibilidad interaccion completa en el resto de líneas
        else
        {
            zRegresa.SetActive(true);
            xAvanza.SetActive(true);
        }


        //Avance del diálogo
        if (Input.GetKeyDown(KeyCode.X) && xAvanza.activeSelf && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            //Si no es la última línea, avanzar
            if (lineaDialogo != 6)
            {
                AvanceDialogo();
            }

            //Si es la última, cerrarlo
            if (lineaDialogo == 6)
            {
                //Debug.Log("Has acabado el juego");
                cuadrotexto.SetActive(false);
                dialogo[5].SetActive(false);
                StartCoroutine(AparecePanelN());
            }
        }


        //Posibilidad de retroceder el diálogo
        if (Input.GetKeyDown(KeyCode.Z) && zRegresa.activeSelf && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            RetrocesoDialogo();


        }
        //Si no deja, dar sonido de error
        else if (Input.GetKeyDown(KeyCode.Z) && lineaDialogo == 0 && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            AudioManager.Instance.PlaySFX("Error");
        }

        //Posibilidad de cerrar el juego con interacción con teclado --- ESTO ERA MÁS PARA CUANDO LOS BOTONES NO FUNCIONABAN
        if (Input.GetKeyDown(KeyCode.Space) && gracias.activeSelf)
        {
            SalirJuego();
        }

    }



    //Cambio de animación de Churro
    IEnumerator ChurroAIdle()
    {
        yield return new WaitForSeconds(4);
        animChurro.SetBool("ChurroCaminaVIC", false);
        animChurro.SetBool("ChurroVICIdle", true);
    }


    //Aparición de texto tras varios segundos
    IEnumerator ApareceTexto()
    {
        yield return new WaitForSeconds(4.5f);
        cuadrotexto.SetActive(true);
        xAvanza.SetActive(true);
        dialogo[0].SetActive(true);
    }


    //Aparición panel negro tras un segundo
    IEnumerator AparecePanelN()
    {
        yield return new WaitForSeconds(1);
        animPanelN.SetBool("Panel_in", true);
        StartCoroutine(ApareceGracias());
    }



    //Aparición pantalla final tras unos segundos
    IEnumerator ApareceGracias()
    {
        yield return new WaitForSeconds(2.5f);
        botonSalir.SetActive(true);
        gracias.SetActive(true);
    }


    public void AvanceDialogo()
    {
        AudioManager.Instance.PlaySFX("Botones");
        dialogo[lineaDialogo].SetActive(false);
        lineaDialogo = (lineaDialogo + 1) % dialogo.Length;
        dialogo[lineaDialogo].SetActive(true);
    }

    public void RetrocesoDialogo()
    {
        AudioManager.Instance.PlaySFX("Volver");
        dialogo[lineaDialogo].SetActive(false);
        lineaDialogo--;
        if (lineaDialogo < 0)
        {
            lineaDialogo += dialogo.Length;
        }

        dialogo[lineaDialogo].SetActive(true);
    }



    public void SalirJuego() //BOTÓN EN CANVAS
    {
        Debug.Log("Sales del juego");
        Application.Quit();
    }
}
