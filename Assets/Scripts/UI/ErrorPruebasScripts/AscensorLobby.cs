using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class AscensorLobby : MonoBehaviour
{
    private GameObject panelElevator;
    private GameObject xElevator;

    private bool isPlayerNear;

    private GameObject panelN;
    private Animator animPanelN;
    void Start()
    {
        panelElevator = GameObject.Find("Panel_Ascensor");
        panelElevator.SetActive(false);

        xElevator = GameObject.Find("xElevator");
        xElevator.SetActive(false);

        isPlayerNear = false;

        panelN = GameObject.Find("Panel_Negro");
        //panelN.SetActive(false);
        animPanelN = panelN.GetComponent<Animator>();
        StartCoroutine(desPanelN());
    }


    void Update()
    {
        if (isPlayerNear)
        {
            xElevator.SetActive(true);
        }
        else
        {
            xElevator.SetActive(false);
        }



        if (xElevator.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            AudioManager.Instance.PlaySFX("Botones");
            panelElevator.SetActive(true);
        }


        if (panelElevator.activeSelf)
        {
            xElevator.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                panelElevator.SetActive(false);
                AudioManager.Instance.PlaySFX("Volver");
            }
        }


        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Jugador en zona de ascensor");
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Jugador ha salido de la zona de ascensor");
        }
    }

public void IrAPlanta1()
    {
        //panelN.SetActive(true);
        AudioManager.Instance.PlaySFX("Botones");
        panelN.GetComponent<Image>().enabled = true;
        animPanelN.SetBool("Panel_in", true);
        panelElevator.SetActive(false);
        xElevator.SetActive(false);
        StartCoroutine(cargaLevel1());
    }

    public void IrError()
    {
        AudioManager.Instance.PlaySFX("Error");
    }


    IEnumerator cargaLevel1()
    {
        yield return new WaitForSeconds(2);

        //CargarEscenaAscensor();
        SceneManager.LoadScene("Level_1");
    }
    

    IEnumerator desPanelN()
    {
        yield return new WaitForSeconds(1.5f);
        //panelN.SetActive(false);
        panelN.GetComponent<Image>().enabled = false;
    }


}
