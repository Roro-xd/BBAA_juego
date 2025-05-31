using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class Ascensor : MonoBehaviour
{

    /*public GameObject[] pisos;
    public int pisoSelect = 0;*/

    //Referente al objeto ascensor
    private GameObject panelElevator;
    private GameObject xElevator;

    //Los botones que aparecen en el panel del ascensor (ambas posibilidades, block y desblock)
    //public GameObject xLobby;
    //public GameObject botonLobby;
    public GameObject botonLobbyBlock;
    //public GameObject xLevel1;
    public GameObject botonLevel1;
    public GameObject botonLevel1Block;
    public GameObject botonBoss;
    public GameObject botonBossBlock;

    //Color colorBlock = new Color(128, 128, 128);
    //private GameObject zInd;

    private bool isPlayerNear;
    //private bool puedoLobby;
    private bool puedoLevel1;
    private bool puedoBoss;

    private GameObject panelN;
    private Animator animPanelN;




    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(UnityEngine.SceneManagement.Scene escena, LoadSceneMode modoEscena)
    {

        if (escena.name == "LobbyInteractuable")
        {
            //puedoLobby = false;
            puedoBoss = false;
            puedoLevel1 = true;
        }
        else if (escena.name == "Level_1")
        {
            //puedoLobby = false;
            puedoBoss = true;
            puedoLevel1 = false;
        }
    }





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
            /*pisos[pisoSelect].SetActive(true);
            
            botLobby.SetActive(true);*/

            /*if (puedoLobby == false)
            {
                botLobbyBlock.SetActive(true);
                botLobby.SetActive(false);
            }
            else
            {
                botLobbyBlock.SetActive(false);
                botLobby.SetActive(true);
            }*/


            /*if (puedoLevel1 == false)
            {
                botLobbyBlock.SetActive(true);
                botLobby.SetActive(false);
            }
            else
            {
                botLevel1Block.SetActive(false);
                botLevel1.SetActive(true);
            }*/

        }


        if (panelElevator.activeSelf)
        {
            xElevator.SetActive(false);
            botonLobbyBlock.SetActive(true);

            /*if (puedoLobby)
            {
                botonLobby.SetActive(true);
                botonLobbyBlock.SetActive(false);
            }
            else if (puedoLobby == false)
            {
                botonLobbyBlock.SetActive(true);
                botonLobby.SetActive(false);
            }*/



            if (puedoLevel1)
            {
                //Debug.Log("El script se está ejecutando correctamente.");
                botonLevel1.SetActive(true);
                botonLevel1Block.SetActive(false);
            }
            else if (puedoLevel1 == false)
            {
                botonLevel1Block.SetActive(true);
                botonLevel1.SetActive(false);
            }



            if (puedoBoss)
            {
                botonBoss.SetActive(true);
                botonBossBlock.SetActive(false);
            }
            else if (puedoBoss == false)
            {
                botonBossBlock.SetActive(true);
                botonBoss.SetActive(false);
            }

            /*if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                RetrocesoPiso();
            }


            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                AvancePiso();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (pisoSelect == 0)
                {
                    IrALobby();
                }
                else if (pisoSelect == 1)
                {
                    IrAPlanta1();
                }
            }*/


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


    /*public void CargarEscenaAscensor()
    {
        PlayerPrefs.SetString("ultimaEscena", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("EnAscensor");
    }*/


    IEnumerator cargaBOSS()
    {
        yield return new WaitForSeconds(2);

        //CargarEscenaAscensor();
        SceneManager.LoadScene("BOSS");
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
