using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_inicio : MonoBehaviour
{

    GameObject panelInicio;
    GameObject panelAjustes;
    GameObject panelExtras;
    GameObject panelCreditos;
    GameObject panelPlayers;
    GameObject panelEnemigos;
    GameObject panelBosses;
    GameObject panelItems;
    GameObject objAudioManager;
    //AudioManager scriptAudioManager;


    void Start()
    {
        //Encontrar y establecer estados de los paneles
        panelInicio = GameObject.Find("Panel_inicio");

        panelAjustes = GameObject.Find("Panel_ajustes");
        panelAjustes.SetActive(false);

        panelExtras = GameObject.Find("Panel_extras");
        panelExtras.SetActive(false);

        panelCreditos = GameObject.Find("Panel_creditos");
        panelCreditos.SetActive(false);

        panelPlayers = GameObject.Find("Panel_players");
        panelPlayers.SetActive(false);

        panelEnemigos = GameObject.Find("Panel_enemigos");
        panelEnemigos.SetActive(false);

        panelBosses = GameObject.Find("Panel_bosses");
        panelBosses.SetActive(false);

        panelItems = GameObject.Find("Panel_items");
        panelItems.SetActive(false);


        StartCoroutine("sonidoSubtitulo");



    }


    void Update()
    {

    }


    //Para los botones de la pantalla de inicio
    public void botonInicioSalir()
    {
        Application.Quit();
    }


    public void botonInicioJugar()
    {
        SceneManager.LoadScene("Lobby"); //CAMBIAR A NOMBRE QUE VAYA A TENER AL FINAL
    }


    public void botonInicioAjustes()
    {
        panelAjustes.SetActive(true);
    }


    public void botonInicioCreditos()
    {
        panelCreditos.SetActive(true);
    }


    //Para los botones de la pantalla de ajustes

    //PONER LAS COSAS DEL VOLUMEN

    //Para los botones de la pantalla de extras
    public void botonAjustesExtras()
    {
        panelExtras.SetActive(true);
    }

    public void botonExtrasVolver()
    {
        panelExtras.SetActive(false);
    }

    //Dentro de los extras
    public void botonDentroExtrasVolver()
    {
        panelPlayers.SetActive(false);
        panelEnemigos.SetActive(false);
        panelBosses.SetActive(false);
        panelItems.SetActive(false);
    }

    public void botonExtrasPlayers()
    {
        panelPlayers.SetActive(true);
    }

    public void botonExtrasEnemigos()
    {
        panelEnemigos.SetActive(true);
    }

    public void botonExtrasBosses()
    {
        panelBosses.SetActive(true);
    }

    public void botonExtrasItems()
    {
        panelItems.SetActive(true);
    }


    public void botonAjustesVolver()
    {
        panelAjustes.SetActive(false);
    }

    public void botonCreditosVolver()
    {
        panelCreditos.SetActive(false);
    }


    //SONIDOS DE LOS BOTONES
    public void SuenaBoton()
    {
        AudioManager.Instance.PlaySFX("Botones");
    }

    public void SuenaVolver()
    {
        AudioManager.Instance.PlaySFX("Volver");

    }

    IEnumerator sonidoSubtitulo()
    {
        yield return new WaitForSeconds(0.33f);
        AudioManager.Instance.PlaySFX("Subtítulo");

    }

}
