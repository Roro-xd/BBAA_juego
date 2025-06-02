using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_Partida : MonoBehaviour
{
    //UI QUE APARECE DURANTE LA PARTIDA: VIDA, HAB ESPECIAL Y DINERO

    //Para obtener las variables de los otros scripts
    private GameObject player;

    //vida
    //ENLAZAR CON LA VIDA DEL GAMEMANAGER O DONDE ESTÉ 
    public int vidaActual;
    private int vidaBase;
    private int vidaMax = 10;
    private int vidasExtraCantidad;

    //Imagen que va a representar y colorear la variable vida
    GameObject visualVida;
    GameObject vidasExtra;
    private RectTransform transfVida;
    GameObject v6Extra;
    GameObject v7Extra;
    GameObject v8Extra;
    GameObject v9Extra;
    GameObject v10Extra;

    //Modificacion por vida adquirida
    private int anchoVida = 0;
    private int incVida = 50;



    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null) return;


        vidaBase = player.GetComponent<Vida>().vidaBase;

        visualVida = GameObject.Find("VisualVidas");
        //Llamar a transformar la imagen de VIDA
        transfVida = visualVida.GetComponent<RectTransform>();

        vidasExtra = GameObject.Find("VisualVidasExtra");
        v6Extra = GameObject.Find("6VidasExtra");
        v7Extra = GameObject.Find("7VidasExtra");
        v8Extra = GameObject.Find("8VidasExtra");
        v9Extra = GameObject.Find("9VidasExtra");
        v10Extra = GameObject.Find("10VidasExtra");
    }


    void Update()
    {
        vidaActual = player.GetComponent<Vida>().vidaActual;

        vidasExtraCantidad = vidaActual - vidaBase;

        if (vidaActual <= 4)
        {
            //La barra coloreada aumenta
            ActualizarVida(); 
            vidasExtra.SetActive(false);
            v10Extra.SetActive(false);
            v6Extra.SetActive(false);
            v7Extra.SetActive(false);
            v8Extra.SetActive(false);
            v9Extra.SetActive(false);
        }
        else if (vidaActual > 4 && vidaActual <= 10)
        {
            AñadirVida();
        }
        //Que no se supere la vida máxima
        else if (vidaActual > vidaMax)
        {
            vidaActual = vidaMax;
        }


    }


    void ActualizarVida()
    {
        int nuevoAncho = anchoVida + (vidaActual * incVida);
        transfVida.sizeDelta = new Vector2(nuevoAncho, transfVida.sizeDelta.y);
    }


    public void AñadirVida()
    {
        //La barra coloreada se queda aumentada al máximo
        transfVida.sizeDelta = new Vector2(vidaBase * incVida, transfVida.sizeDelta.y);
        //Activar la imagen de vidas Extra
        vidasExtra.SetActive(true);


        if (vidasExtraCantidad == 2)
        {
            v6Extra.SetActive(true);
        }
        else
        {
            v6Extra.SetActive(false);
        }


        if (vidasExtraCantidad == 3)
        {
            v6Extra.SetActive(true);
            v7Extra.SetActive(true);
        }
        else
        {
            v7Extra.SetActive(false);
        }

        if (vidasExtraCantidad == 4)
        {
            v6Extra.SetActive(true);
            v7Extra.SetActive(true);
            v8Extra.SetActive(true);
        }
        else
        {
            v8Extra.SetActive(false);
        }


        if (vidasExtraCantidad == 5)
        {
            v6Extra.SetActive(true);
            v7Extra.SetActive(true);
            v8Extra.SetActive(true);
            v9Extra.SetActive(true);
        }
        else
        {
            v9Extra.SetActive(false);
        }


        if (vidasExtraCantidad == 6)
        {
            v10Extra.SetActive(true);
            v6Extra.SetActive(true);
            v7Extra.SetActive(true);
            v8Extra.SetActive(true);
            v9Extra.SetActive(true);
        }
        else
        {
            v10Extra.SetActive(false);
        }
    }

}
