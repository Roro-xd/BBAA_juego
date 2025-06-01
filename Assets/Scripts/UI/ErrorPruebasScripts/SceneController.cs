using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    //SCRIPT PARA INTERPRETAR LA ESCENA QUE VA A CONTINUACIÓN DE "EnAscensor", PUES SE REPITE DOS VECES DURANTE LA DEMO

    //Variable para guardar la escena anterior
    //public static string ultimaEscena;


    //Guardar escena actual y cargar la escena EnAscensor
    public void CargarEscenaAscensor()
    {
        PlayerPrefs.SetString("ultimaEscena", SceneManager.GetActiveScene().name);
        //ultimaEscena = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("EnAscensor");
    }

    //Finaliza la escena EnAscensor y te dirige a la que toque según la escena anterior ya guardada
    public void FinalizarEscenaAscensor()
    {
        string ultimaEscena = PlayerPrefs.GetString("ultimaEscena");

        if (ultimaEscena == "LobbyInteractuable")
        {
            SceneManager.LoadScene("Level_1");
        }
        else if (ultimaEscena == "Level_1")
        {
            SceneManager.LoadScene("BOSS");
        }
        /*else
        {
            SceneManager.LoadScene("EscenaPorDefecto");
        }*/
    }
}
