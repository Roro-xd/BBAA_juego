using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_inicio : MonoBehaviour
{
    //Menciono todos los paneles del inicio para poder manejarlos
    GameObject panelInicio;
    GameObject panelAjustes;
    GameObject panelExtras;
    GameObject panelCreditos;
    GameObject panelPlayers;
    GameObject panelEnemigos;
    GameObject panelBosses;
    GameObject panelItems;


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


        //Sonido que coincide con la aparición de los textos del subtítulo
        StartCoroutine("sonidoSubtitulo");
    }



    //Para salir del juego
    public void botonInicioSalir()
    {
        Application.Quit();
    }


    //Para empezar a jugar
    public void botonInicioJugar()
    {
        SceneManager.LoadScene("InicioLobby");
    }


    //Para abrir los ajustes
    public void botonInicioAjustes()
    {
        panelAjustes.SetActive(true);
    }


    //Para abrir los créditos
    public void botonInicioCreditos()
    {
        panelCreditos.SetActive(true);
    }


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

    //Para cerrar ajustes
    public void botonAjustesVolver()
    {
        panelAjustes.SetActive(false);
    }

    //Para cerrar los créditos
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

    //Tiempo de espera para el subtítulo (que no suene nada más abrir el juego porque puede aparecer desincronizado)
    IEnumerator sonidoSubtitulo()
    {
        yield return new WaitForSeconds(0.33f);
        AudioManager.Instance.PlaySFX("Subtítulo");
    }

}
