using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AscensorLevel1 : MonoBehaviour
{
    //Indicadores del ascensor
    private GameObject panelElevator;
    private GameObject xElevator;

    //Bool de entrada en rango de ascensor
    private bool isPlayerNear;

    //Panel negro para cambio de escena
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
        animPanelN = panelN.GetComponent<Animator>();
        //"Desactivar" el panel tras la primera anim (desactivarlo por completo me daba problemas)
        StartCoroutine(desPanelN());
    }


    void Update()
    {
        //Activar posibilidad de ascensor si se entra en su rango
        if (isPlayerNear)
        {
            xElevator.SetActive(true);
        }
        else
        {
            xElevator.SetActive(false);
        }


        //Abrir el panel de elección de pisos
        if (xElevator.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            AudioManager.Instance.PlaySFX("Botones");
            panelElevator.SetActive(true);
        }


        if (panelElevator.activeSelf)
        {
            xElevator.SetActive(false);

            //Salir del panel
            if (Input.GetKeyDown(KeyCode.Z))
            {
                panelElevator.SetActive(false);
                AudioManager.Instance.PlaySFX("Volver");
            }
        }


        
    }


    //Entrar en su rango
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Jugador en zona de ascensor");
        }
    }


    //Salir de su rango
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Jugador ha salido de la zona de ascensor");
        }
    }


    //BOTÓN PARA IR AL BOSS
    public void IrABoss()
    {
        //panelN.SetActive(true);
        AudioManager.Instance.PlaySFX("Botones");
        panelN.GetComponent<Image>().enabled = true;
        animPanelN.SetBool("Panel_in", true);
        panelElevator.SetActive(false);
        xElevator.SetActive(false);
        StartCoroutine(cargaBOSS());
    }


    //BOTÓN DE ERROR (no se puede ir a ese piso)
    public void IrError()
    {
        AudioManager.Instance.PlaySFX("Error");
    }


    //Tiempo de espera antes de cambiar de escena
    IEnumerator cargaBOSS()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("BOSS");
    }
    

    //"Desactivar" panel negro
    IEnumerator desPanelN()
    {
        yield return new WaitForSeconds(1.5f);
        panelN.GetComponent<Image>().enabled = false;
    }
}
