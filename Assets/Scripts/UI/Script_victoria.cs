using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Script_victoria : MonoBehaviour
{

    private GameObject churro;
    private Animator animChurro;

    private GameObject napo;
    private Animator animNapo;

    private GameObject yori;
    private Animator animYori;


    public GameObject[] dialogo;
    public int lineaDialogo = 0;
    public GameObject zRegresa;
    public GameObject xAvanza;
    public GameObject cuadrotexto;


    public GameObject panelN;
    private Animator animPanelN;
    public GameObject botonSalir;
    public GameObject gracias;


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
        StartCoroutine("ApareceTexto");


    }



    void Update()
    {
        if (lineaDialogo == 0)
        {
            zRegresa.SetActive(false);
        }
        else if (lineaDialogo == 3)
        {
            animNapo.SetBool("NapoVICCamina", true);
            animNapo.SetBool("NapoParada", false);
            animYori.SetBool("YoriParado", false);
            animYori.SetBool("Yor_VIC_Caminado", true);
        }
        else if (lineaDialogo == 6)
        {
            zRegresa.SetActive(false);
            xAvanza.SetActive(false);
        }
        else
        {
            zRegresa.SetActive(true);
            xAvanza.SetActive(true);
        }



        if (Input.GetKeyDown(KeyCode.X) && xAvanza.activeSelf)
        {
            if (lineaDialogo != 6)
            {
                AvanceDialogo();
            }

            if (lineaDialogo == 6)
            {
                Debug.Log("Has acabado el juego");
                cuadrotexto.SetActive(false);
                dialogo[5].SetActive(false);
                StartCoroutine(AparecePanelN());
            }
        }


        if (Input.GetKeyDown(KeyCode.Z) && zRegresa.activeSelf)
        {
            RetrocesoDialogo();
        }


    }

    IEnumerator ChurroAIdle()
    {
        yield return new WaitForSeconds(4);
        animChurro.SetBool("ChurroCaminaVIC", false);
        animChurro.SetBool("ChurroVICIdle", true);
    }

    IEnumerator ApareceTexto()
    {
        yield return new WaitForSeconds(4.5f);
        cuadrotexto.SetActive(true);
        xAvanza.SetActive(true);
        dialogo[0].SetActive(true);
    }


    IEnumerator AparecePanelN()
    {
        yield return new WaitForSeconds(1);
        animPanelN.SetBool("Panel_in", true);
        StartCoroutine(ApareceGracias());
    }

    IEnumerator ApareceGracias()
    {
        yield return new WaitForSeconds(2);
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
    

    public void SalirJuego()
    {
        Debug.Log("Sales del juego");
        Application.Quit();
    }
}
