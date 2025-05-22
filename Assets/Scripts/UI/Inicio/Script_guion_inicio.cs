using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Script_guion_inicio : MonoBehaviour
{

    public GameObject indicarZ;
    public GameObject dialogo1;
    public GameObject dialogo2;
    public GameObject dialogo3;
    public GameObject dialogo4;
    public GameObject dialogo5;
    public GameObject cuadroTexto;


    public GameObject[] conversaciones;
    public int selectedDialogue = 0;

    public GameObject personajes;
    private Animator animPersonajes;
    public GameObject lobby;
    private Animator animLobby;
    public GameObject bun;
    private Animator bunAnim;
    //SÉ QUE ESTÁIS HACIENDO LOS SPRITES, PERO AUN NO HE HECHO COMIT
    /*public GameObject churro;
    private Animator churroAnim;
    public GameObject napo;
    private Animator napoAnim;
    public GameObject yori;
    private Animator yoriAnim;*/

    //private float volumeMusica;

    void Start()
    {
        //volumeMusica = PlayerPrefs.GetFloat("MusicaGuardada", 1f);

        animPersonajes = personajes.GetComponent<Animator>();
        animLobby = lobby.GetComponent<Animator>();

        bunAnim = bun.GetComponent<Animator>();

        StartCoroutine("pausaTexto6s");

        //AudioManager.Instance.PlayMusica("VocesFondo");

    }



    void Update()
    {

        if (selectedDialogue == 2)
        {
            bunAnim.SetBool("BuParado", true);
            bunAnim.SetBool("BuCamina", false);

        }
        /*else if (selectedDialogue == 4)
        {
            churroAnim.SetBool("ChurroParado", true);
            churroAnim.SetBool("ChurroCamina", false);
            napoAnim.SetBool("NapoParada", true);
            napoAnim.SetBool("NapoCamina", false);
            yoriAnim.SetBool("YoriParado", true);
            yoriAnim.SetBool("YoriCamina", false);

        }*/
        else if (selectedDialogue == 5)
        {
            bunAnim.SetBool("BuParado", false);
            bunAnim.SetBool("BuCamina", true);
        }
        else if (selectedDialogue == 6 || selectedDialogue == 7 || selectedDialogue == 8 || selectedDialogue == 9) //CHURRO ACTIVO
        {
            /*churroAnim.SetBool("ChurroIdle", true);
            churroAnim.SetBool("ChurroParado", false);*/
            bunAnim.SetBool("BuParado", true);
            bunAnim.SetBool("BuIdle", false);
            bunAnim.SetBool("BuCamina", false);
            /*napoAnim.SetBool("NapoParada", true);
            napoAnim.SetBool("NapoIdle", false);
            yoriAnim.SetBool("YoriParado", true);
            yoriAnim.SetBool("YoriIdle", false);*/

        }
        else if (selectedDialogue == 10 || selectedDialogue == 11 || selectedDialogue == 12 || selectedDialogue == 13) //BUN ACTIVO
        {
            /*churroAnim.SetBool("ChurroIdle", false);
            churroAnim.SetBool("ChurroParado", true);*/
            bunAnim.SetBool("BuParado", false);
            bunAnim.SetBool("BuIdle", true);
            /*napoAnim.SetBool("NapoParada", true);
            napoAnim.SetBool("NapoIdle", false);
            yoriAnim.SetBool("YoriParado", true);
            yoriAnim.SetBool("YoriIdle", false);*/

        }
        else if (selectedDialogue == 14 || selectedDialogue == 15 || selectedDialogue == 16 || selectedDialogue == 17) //NAPO ACTIVO
        {
            /*churroAnim.SetBool("ChurroIdle", false);
            churroAnim.SetBool("ChurroParado", true);*/
            bunAnim.SetBool("BuParado", true);
            bunAnim.SetBool("BuIdle", false);
            /*napoAnim.SetBool("NapoParada", false);
            napoAnim.SetBool("NapoIdle", true);
            yoriAnim.SetBool("YoriParado", true);
            yoriAnim.SetBool("YoriIdle", false);*/

        }
        else if (selectedDialogue == 10 || selectedDialogue == 11 || selectedDialogue == 12 || selectedDialogue == 13) //YORI ACTIVO
        {
            /*churroAnim.SetBool("ChurroIdle", false);
            churroAnim.SetBool("ChurroParado", true);*/
            //bunAnim.SetBool("BuParado", true);
            //bunAnim.SetBool("BuIdle", false);
            /*napoAnim.SetBool("NapoParada", true);
            napoAnim.SetBool("NapoIdle", false);
            yoriAnim.SetBool("YoriParado", false);
            yoriAnim.SetBool("YoriIdle", true);*/

        }




        if (Input.GetKeyDown(KeyCode.X) && cuadroTexto.activeSelf == true)
        {
            // hola
            if (selectedDialogue == 23)
            {

                cuadroTexto.SetActive(false);
                dialogo5.SetActive(false);
                animPersonajes.SetBool("DesPjs", true);
                animLobby.SetBool("Desaparecer", true);

                StartCoroutine("cambioEscena");

            }
            else
            {
                AudioManager.Instance.PlaySFX("Botones");


                if (selectedDialogue == 1)
                {
                    cuadroTexto.SetActive(false);
                    dialogo2.SetActive(false);
                    animPersonajes.SetBool("Silueta1", true);
                    StartCoroutine("pausaTexto3s");
                    StartCoroutine("pausaAvanceTextos3s");

                }
                else if (selectedDialogue == 3)
                {

                    cuadroTexto.SetActive(false);
                    dialogo3.SetActive(false);
                    animPersonajes.SetBool("Siluetas", true);
                    StartCoroutine("pausaTexto3s");
                    StartCoroutine("pausaAvanceTextos3s");

                }
                else if (selectedDialogue == 5)
                {

                    cuadroTexto.SetActive(false);
                    dialogo4.SetActive(false);
                    animPersonajes.SetBool("PosPjs", true);
                    StartCoroutine("pausaTexto3s");
                    StartCoroutine("pausaAvanceTextos3s");

                }
                else
                {
                    AvanceDialogo();
                    if (selectedDialogue == 7)
                    {
                        AudioManager.Instance.PlayVoces("Churro1");
                    }
                    else if (selectedDialogue == 8)
                    {
                        AudioManager.Instance.PlayVoces("Churro2");
                    }
                    else if (selectedDialogue == 9)
                    {
                        AudioManager.Instance.PlayVoces("Churro3");
                    }
                    else if (selectedDialogue == 10)
                    {
                        AudioManager.Instance.PlayVoces("Bun1");
                    }
                    else if (selectedDialogue == 11)
                    {
                        AudioManager.Instance.PlayVoces("Bun2");
                    }
                    else if (selectedDialogue == 12)
                    {
                        AudioManager.Instance.PlayVoces("Bun3");
                    }
                    else if (selectedDialogue == 13)
                    {
                        AudioManager.Instance.PlayVoces("Bun4");
                    }
                    else if (selectedDialogue == 14)
                    {
                        AudioManager.Instance.PlayVoces("Napo1");
                    }
                    else if (selectedDialogue == 15)
                    {
                        AudioManager.Instance.PlayVoces("Napo2");
                    }
                    else if (selectedDialogue == 16)
                    {
                        AudioManager.Instance.PlayVoces("Napo3");
                    }
                    else if (selectedDialogue == 17)
                    {
                        AudioManager.Instance.PlayVoces("Napo4");
                    }
                    else if (selectedDialogue == 18)
                    {
                        AudioManager.Instance.PlayVoces("Yor1");
                    }
                    else if (selectedDialogue == 19)
                    {
                        AudioManager.Instance.PlayVoces("Yor2");
                    }
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Z) && cuadroTexto.activeSelf == true)
        {
            if (selectedDialogue == 0 || selectedDialogue == 2 || selectedDialogue == 4 || selectedDialogue == 6)
            {
                AudioManager.Instance.PlaySFX("Error");
            }
            else
            {
                AudioManager.Instance.PlaySFX("Volver");
                conversaciones[selectedDialogue].SetActive(false);
                selectedDialogue--;
                if (selectedDialogue < 0)
                {
                    selectedDialogue += conversaciones.Length;
                }

                conversaciones[selectedDialogue].SetActive(true);

            }
        }


        if (selectedDialogue == 0 || selectedDialogue == 2 || selectedDialogue == 4 || selectedDialogue == 6)
        {
            indicarZ.SetActive(false);
        }
        else
        {
            indicarZ.SetActive(true);
        }


    }

    IEnumerator pausaTexto6s()
    {
        yield return new WaitForSeconds(6);
        dialogo1.SetActive(true);
        cuadroTexto.SetActive(true);
    }

    IEnumerator pausaTexto3s()
    {
        yield return new WaitForSeconds(3);
        cuadroTexto.SetActive(true);
    }


    IEnumerator pausaAvanceTextos3s()
    {
        yield return new WaitForSeconds(3);
        AvanceDialogo();
    }

    IEnumerator cambioEscena()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Inicio"); //CAMBIAR A PARTIDA CUANDO ESTÉ PREPARADO

    }

    public void AvanceDialogo()
    { 
        conversaciones[selectedDialogue].SetActive(false);
        selectedDialogue = (selectedDialogue + 1) % conversaciones.Length;
        conversaciones[selectedDialogue].SetActive(true);
    }
    

}
