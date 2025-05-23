using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_Partida : MonoBehaviour
{
    //UI QUE APARECE DURANTE LA PARTIDA: VIDA, HAB ESPECIAL Y DINERO

    //vida
    //ENLAZAR CON LA VIDA DEL GAMEMANAGER O DONDE ESTÉ 
    public int vidaActual = 4;
    //Imagen que va a representar y colorear la variable vida
    public GameObject visualVida;
    public GameObject vidasExtra5;
    public GameObject vidasExtra6;
    public GameObject vidasExtra7;
    public GameObject vidasExtra8;
    public GameObject vidasExtra9;
    public GameObject vidasExtra10;
    public GameObject vidasExtraVisualNeutro;
    private RectTransform transfVida;
    private RectTransform transfNeutroExtra;
    //Modificacion por vida adquirida
    private int anchoVida = 0;
    private int incVida = 50;

    //habilidad especial
    //Creo que es mucho más fácil enlazar el objeto y poner cada animación cuando toca junto a lo ya scripteado
    //PRUEBA
    public GameObject visualHabEsp;
    private Animator animatorHab;




    void Start()
    {
        //Llamar a transformar la imagen de VIDA
        transfVida = visualVida.GetComponent<RectTransform>();
        transfNeutroExtra = vidasExtraVisualNeutro.GetComponent<RectTransform>();


        //PRUEBA HAB ESP
        animatorHab = visualHabEsp.GetComponent<Animator>();
    }


    void Update()
    {
        if (vidaActual <= 4)
        {
            ActualizarVida();
        }
        

        if (vidaActual > 4)
        {
            vidasExtraVisualNeutro.SetActive(true);

            int nuevoAnchoNeutro = ((vidaActual-4) * incVida);
            transfNeutroExtra.sizeDelta = new Vector2(nuevoAnchoNeutro, transfNeutroExtra.sizeDelta.y);

            if (vidaActual == 5)
            {
                vidasExtra5.SetActive(true);
            }
            else if (vidaActual == 6)
            {
                vidasExtra6.SetActive(true);
            }
            else if (vidaActual == 7)
            {
                vidasExtra7.SetActive(true);
            }
            else if (vidaActual == 8)
            {
                vidasExtra8.SetActive(true);
            }
            else if (vidaActual == 9)
            {
                vidasExtra9.SetActive(true);
            }
            else if (vidaActual == 10)
            {
                vidasExtra10.SetActive(true);
            }
        }
        else
        {
            vidasExtraVisualNeutro.SetActive(false);
        }


        if (vidaActual > 10)
            {
                vidaActual = 10;
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

    //PRUEBA HAB ESP
    IEnumerator VueltaACooldown(){
        yield return new WaitForSeconds(2);
        animatorHab.SetBool("HabUsando", false);
    }
}
