using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Script_guion_inicio : MonoBehaviour
{

    //Indico elementos de UI
    public GameObject indicarZ;
    public GameObject indicarXbase;
    public GameObject indicarXmod;
    public GameObject botonSaltar;
    public GameObject cuadroTexto;
    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;
    public GameObject panelTextoInicioCurso;


    //Hago tabla de conversaciones
    public GameObject[] conversaciones;
    public int selectedDialogue = 0;


    //Indico lo relativo a las animaciones
    public GameObject personajes;
    private Animator animPersonajes;

    public GameObject lobby;
    private Animator animLobby;

    public GameObject bun;
    private Animator bunAnim;

    public GameObject churro;
    private Animator churroAnim;

    public GameObject napo;
    private Animator napoAnim;

    public GameObject yori;
    private Animator yoriAnim;


    //Panel negro para fundido
    public GameObject panelN;
    private Animator animPanelN;



    void Start()
    {
        //Llamo a cada Animator
        animPersonajes = personajes.GetComponent<Animator>();
        animLobby = lobby.GetComponent<Animator>();
        animPanelN = panelN.GetComponent<Animator>();
        bunAnim = bun.GetComponent<Animator>();
        churroAnim = churro.GetComponent<Animator>();
        napoAnim = napo.GetComponent<Animator>();
        yoriAnim = yori.GetComponent<Animator>();

        //Pasan 6s hasta que aparecen los dialogos
        StartCoroutine("pausaTexto6s");

        Destroy(panelTextoInicioCurso, 4.5f);
    }



    void Update()
    {
        //QUÉ INDICADOR DE X SACAR SEGÚN DIÁLOGO
        if ((selectedDialogue <= 5 || selectedDialogue >= 20) && cuadroTexto.activeSelf == true)
        {
            indicarXbase.SetActive(true);
            indicarXmod.SetActive(false);
        }
        else if (selectedDialogue >= 6 && selectedDialogue <= 19 && cuadroTexto.activeSelf == true)
        { 
            indicarXbase.SetActive(false);
            indicarXmod.SetActive(true);
        }


        //Esto para que visualmente no aparezca el boton de retroceder cuando no se pueda
        if (selectedDialogue == 0 || selectedDialogue == 2 || selectedDialogue == 4 || selectedDialogue == 6)
        {
            indicarZ.SetActive(false);
        }
        else
        {
            indicarZ.SetActive(true);
        }



        //ANIMACIONES DE CADA PERSONAJE SEGÚN LOS DIALOGOS
        //Silueta de Buñuelo se aproxima
        if (selectedDialogue == 2)
        {
            bunAnim.SetBool("BuParado", true);
            bunAnim.SetBool("BuCamina", false);

        }
        //El resto de siluetas se aproximan ---------------------------INCLUIR CUANDO ESTÉN LOS CAMINADOS
        /*else if (selectedDialogue == 4)
        {
            churroAnim.SetBool("ChurroParado", true);
            churroAnim.SetBool("ChurroCamina", false);
            napoAnim.SetBool("NapoParada", true);
            napoAnim.SetBool("NapoCamina", false);
            yoriAnim.SetBool("YoriParado", true);
            yoriAnim.SetBool("YoriCamina", false);

        }*/
        //CHURRO ACTIVO
        else if (selectedDialogue >= 6 && selectedDialogue <= 9)
        {
            churroAnim.SetBool("ChurroIdle", true);
            churroAnim.SetBool("ChurroParado", false);
            bunAnim.SetBool("BuParado", true);
            bunAnim.SetBool("BuIdle", false);
            bunAnim.SetBool("BuCamina", false);
            napoAnim.SetBool("NapoParada", true);
            napoAnim.SetBool("NapoIdle", false);
            yoriAnim.SetBool("YoriParado", true);
            yoriAnim.SetBool("YoriIdle", false);

        }
        //BUN ACTIVO
        else if (selectedDialogue >= 10 && selectedDialogue <= 13)
        {
            churroAnim.SetBool("ChurroIdle", false);
            churroAnim.SetBool("ChurroParado", true);
            bunAnim.SetBool("BuParado", false);
            bunAnim.SetBool("BuIdle", true);
            napoAnim.SetBool("NapoParada", true);
            napoAnim.SetBool("NapoIdle", false);

        }
        //NAPO ACTIVO
        else if (selectedDialogue >= 14 && selectedDialogue <= 17)
        {
            bunAnim.SetBool("BuParado", true);
            bunAnim.SetBool("BuIdle", false);
            napoAnim.SetBool("NapoParada", false);
            napoAnim.SetBool("NapoIdle", true);
            yoriAnim.SetBool("YoriParado", true);
            yoriAnim.SetBool("YoriIdle", false);

        }
        //YORI ACTIVO
        else if (selectedDialogue >= 18 && selectedDialogue <= 22)
        {
            napoAnim.SetBool("NapoParada", true);
            napoAnim.SetBool("NapoIdle", false);
            yoriAnim.SetBool("YoriParado", false);
            yoriAnim.SetBool("YoriIdle", true);

        }
        //Ultimo dialogo
        else if (selectedDialogue == 23)
        {
            yoriAnim.SetBool("YoriParado", true);
            yoriAnim.SetBool("YoriIdle", false);
        }



        //PRESIONAR TECLA INDICADA (X) --- AVANZAR (+que el texto esté activo porque sino se pasan los dialogos sin leer)
        //Todo lo extra de los paneles para que no se pueda retroceder mientras se está en pausa
        if (Input.GetKeyDown(KeyCode.X) && cuadroTexto.activeSelf == true && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            //Indicación de qué ocurre cuando se avanza en el último diálogo
            if (selectedDialogue == 23)
            {
                //Ocultar toda la UI
                cuadroTexto.SetActive(false);
                botonSaltar.SetActive(false);
                conversaciones[23].SetActive(false);
                //Activar panel negro (fundido en negro)
                animPanelN.SetBool("Panel_in", true);

                //Que pasen unos segundos hasta el cambio de escena
                StartCoroutine("cambioEscena");

            }
            else
            {
                //Si no es la ultima escena, que suene el boton, PERO
                AudioManager.Instance.PlaySFX("Botones");

                //ANIMACIÓN 1 EN LA ESCENA
                if (selectedDialogue == 1)
                {
                    cuadroTexto.SetActive(false);
                    conversaciones[1].SetActive(false);
                    animPersonajes.SetBool("Silueta1", true);
                    StartCoroutine("pausaTexto3s");
                }

                //ANIMACIÓN 2 EN LA ESCENA
                else if (selectedDialogue == 3)
                {
                    cuadroTexto.SetActive(false);
                    conversaciones[3].SetActive(false);
                    animPersonajes.SetBool("Siluetas", true);
                    StartCoroutine("pausaTexto3s");
                }

                //ANIMACIÓN 3 EN LA ESCENA
                else if (selectedDialogue == 5)
                {
                    cuadroTexto.SetActive(false);
                    conversaciones[5].SetActive(false);
                    bunAnim.SetBool("BuParado", false);
                    bunAnim.SetBool("BuCamina", true);
                    animPersonajes.SetBool("PosPjs", true);
                    StartCoroutine("pausaTexto3s");
                }

                else
                {   //SI NO HAY ANIM EN EL DIALOGO, avanzar dialogo
                    AvanceDialogo();

                    //En los casos especificados, reproducir audio al avanzar
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


        //PRESIONAR TECLA INDICADA (Z) --- RETROCEDER (+que el texto esté activo porque sino se pasan los dialogos sin leer)
        //Todo lo extra de los paneles para que no se pueda retroceder mientras se está en pausa
        if (Input.GetKeyDown(KeyCode.Z) && cuadroTexto.activeSelf == true && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            //No dejar que se retroceda en algunos puntos
            if (selectedDialogue == 0 || selectedDialogue == 2 || selectedDialogue == 4 || selectedDialogue == 6)
            {
                AudioManager.Instance.PlaySFX("Error");
            }
            else
            {
                //Si deja, retroceder
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
    }


    //Aparición inicial del texto despues de unos segundos
    IEnumerator pausaTexto6s()
    {
        yield return new WaitForSeconds(6);
        conversaciones[0].SetActive(true);
        cuadroTexto.SetActive(true);
        botonSaltar.SetActive(true);
    }

    //Aparicion del texto despues de una anim
    IEnumerator pausaTexto3s()
    {
        yield return new WaitForSeconds(3);
        cuadroTexto.SetActive(true);
        AvanceDialogo();
    }

    //Que le de tiempo a animar el panel negro antes de pasar de escena
    IEnumerator cambioEscena()
    {
        yield return new WaitForSeconds(3);
        /////audioManager.otrosSource.Stop();
        SceneManager.LoadScene("Inicio"); //CAMBIAR A PARTIDA CUANDO ESTÉ PREPARADO

    }


    public void AvanceDialogo()
    {
        conversaciones[selectedDialogue].SetActive(false);
        selectedDialogue = (selectedDialogue + 1) % conversaciones.Length;
        conversaciones[selectedDialogue].SetActive(true);
    }


    //Para el boton de saltar la escena
    public void Saltar()
    {
        //audioManager.otrosSource.Stop();
        SceneManager.LoadScene("Level_1");
    }

}
