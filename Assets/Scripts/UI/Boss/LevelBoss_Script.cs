using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoss_Script : MonoBehaviour
{
    public GameObject[] textos;
    public int numTexto = 0;

    public GameObject zRegresa;
    public GameObject xAvanza;
    public GameObject cuadrotexto;

    public GameObject panelIndBoss;
    public GameObject textosConj;

    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;
    public GameObject sliderChurro;


    void Start()
    {
        StartCoroutine(AparicionTexto());
    }

    // Update is called once per frame
    void Update()
    {
        if (numTexto == 0)
        {
            zRegresa.SetActive(false);
        }
        else if (numTexto == 3)
        {
            zRegresa.SetActive(false);
            xAvanza.SetActive(false);
        }
        else
        {
            zRegresa.SetActive(true);
            xAvanza.SetActive(true);
        }



        if (Input.GetKeyDown(KeyCode.X) && xAvanza.activeSelf  && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            if (numTexto != 3)
            {
                AvanceTexto();
            }

            if (numTexto == 3)
            {
                cuadrotexto.SetActive(false);
                //textos[2].SetActive(false);
                panelIndBoss.SetActive(true);
                sliderChurro.SetActive(true);
                //Destroy(panelIndBoss, 3.5f);
                Destroy(textosConj);
            }
        }



        if (Input.GetKeyDown(KeyCode.Z) && zRegresa.activeSelf  && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            RetrocesoTexto();


        }
        else if (Input.GetKeyDown(KeyCode.Z) && numTexto == 0  && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            AudioManager.Instance.PlaySFX("Error");
        }



    }




    public void AvanceTexto()
    {
        AudioManager.Instance.PlaySFX("Botones");
        textos[numTexto].SetActive(false);
        numTexto = (numTexto + 1) % textos.Length;
        textos[numTexto].SetActive(true);
    }

    public void RetrocesoTexto()
    {
        AudioManager.Instance.PlaySFX("Volver");
        textos[numTexto].SetActive(false);
        numTexto--;
        if (numTexto < 0)
        {
            numTexto += textos.Length;
        }

        textos[numTexto].SetActive(true);
    }


    IEnumerator AparicionTexto()
    {
        yield return new WaitForSeconds(0.5f);
        xAvanza.SetActive(true);
        cuadrotexto.SetActive(true);
        textos[0].SetActive(true);
    }

}
