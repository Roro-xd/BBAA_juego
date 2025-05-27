using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class Ascensor : MonoBehaviour
{

    public GameObject[] pisos;
    public int pisoSelect = 0;

    private GameObject panelElevator;
    private GameObject xElevator;
    //public GameObject xLobby;
    public GameObject botLobby;
    private GameObject botLobbyBlock;
    //public GameObject xLevel1;
    public GameObject botLevel1;
    private GameObject botLevel1Block;

    Color colorBlock = new Color(128, 128, 128);
    //private GameObject zInd;

    private bool isPlayerNear;
    //private bool puedoLobby;
    private bool puedoLevel1;




    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(UnityEngine.SceneManagement.Scene escena, LoadSceneMode modoEscena)
    {

        /*if (escena.name != "Lobby")
        {
            puedoLobby = true;
        }
        else if (escena.name == "Lobby")
        {
            puedoLobby = false;
        }*/


        if (escena.name != "Level_1")
        {
            puedoLevel1 = true;
        }
        else if (escena.name == "Level_1")
        {
            puedoLevel1 = false;
        }
    }





    void Start()
    {

        panelElevator = GameObject.Find("Panel_Ascensor");
        panelElevator.SetActive(false);

        xElevator = GameObject.Find("xElevator");
        xElevator.SetActive(false);

        botLevel1Block = GameObject.Find("botLevel1_block");
        botLevel1Block.SetActive(false);

        botLobbyBlock = GameObject.Find("botLobby_block");
        botLobbyBlock.SetActive(false);

        isPlayerNear = false;

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
            pisos[pisoSelect].SetActive(true);
            
            botLobby.SetActive(true);


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


            if (puedoLevel1 == false)
            {
                botLobbyBlock.SetActive(true);
                botLobby.SetActive(false);
            }
            else
            {
                botLevel1Block.SetActive(false);
                botLevel1.SetActive(true);
            }

        }


        if (panelElevator.activeSelf)
        {
            xElevator.SetActive(false);

            if (Input.GetKeyDown(KeyCode.UpArrow))
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
            }


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
        }
    }


    public void IrALobby()
    {
        SceneManager.LoadScene("BOSS");
        /*if (puedoLobby)
        {
            SceneManager.LoadScene("BOSS");
        }
        else
        {
            AudioManager.Instance.PlaySFX("Error");
        }*/
    }

    public void IrAPlanta1()
    {
        if (puedoLevel1)
        {
            SceneManager.LoadScene("Level_1");
        }
        else
        {
            AudioManager.Instance.PlaySFX("Error");
        }
    }
    


    public void AvancePiso()
    {
        AudioManager.Instance.PlaySFX("Botones");
        pisos[pisoSelect].SetActive(false);
        pisoSelect = (pisoSelect + 1) % pisos.Length;
        pisos[pisoSelect].SetActive(true);
    }


    public void RetrocesoPiso()
    { 
        AudioManager.Instance.PlaySFX("Botones");
        pisos[pisoSelect].SetActive(false);
        pisoSelect--;
            if (pisoSelect < 0)
            {
                pisoSelect += pisos.Length;
            }

        pisos[pisoSelect].SetActive(true);
    }
}
