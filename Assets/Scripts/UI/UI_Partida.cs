using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_Partida : MonoBehaviour
{
    //UI QUE APARECE DURANTE LA PARTIDA: VIDA, HAB ESPECIAL Y DINERO

    //vida
    //ENLAZAR CON LA VIDA DEL GAMEMANAGER O DONDE ESTÉ 
    public int vidaActual = 4;
    private int vidaBase = 4;
    private int vidaMax = 10;
    public int vidasExtraCantidad = 1;

    //Imagen que va a representar y colorear la variable vida
    public GameObject visualVida;
    public GameObject vidasExtra;
    private RectTransform transfVida;
    public GameObject v6Extra;
    public GameObject v7Extra;
    public GameObject v8Extra;
    public GameObject v9Extra;
    public GameObject v10Extra;

    //Modificacion por vida adquirida
    private int anchoVida = 0;
    private int incVida = 50;
    //private int incExtras = 54;

    //habilidad especial
    //Creo que es mucho más fácil enlazar el objeto y poner cada animación cuando toca junto a lo ya scripteado
    //PRUEBA
    public GameObject visualHabEsp;
    private Animator animatorHab;




    void Start()
    {
        //Llamar a transformar la imagen de VIDA
        transfVida = visualVida.GetComponent<RectTransform>();

        //PRUEBA HAB ESP
        animatorHab = visualHabEsp.GetComponent<Animator>();
    }


    void Update()
    {
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

        //PRUEBA HAB ESP
        if (Input.GetKey(KeyCode.Space))
        {
            animatorHab.SetBool("HabUsando", true);
            StartCoroutine("VueltaACooldown");

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







        /*
        vidasExtra.transform.position.x + incExtras * (vidasExtraCantidad - 1)
        //Repetirlas según necesite
        for (int i = 1; i <= vidaMax; i++)
        {
            Vector3 posVidasExtras = new Vector3(vidasExtra.transform.position.x + (i * incExtras), vidasExtra.transform.position.y, vidasExtra.transform.position.z);
            Instantiate(vidasExtra, posVidasExtras, Quaternion.identity);
        }*/
    }

    //PRUEBA HAB ESP
    IEnumerator VueltaACooldown(){
        yield return new WaitForSeconds(2);
        animatorHab.SetBool("HabUsando", false);
    }
}
