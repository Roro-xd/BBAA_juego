using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntuacionFinal : MonoBehaviour
{

    //Este script va en el obj texto donde vaya a ir el valor
    string puntuacionFinal;

    public int vidaActual;
    public int dano;
    public int dinero;

    public GameObject stats;

    void Start()
    {
        stats.GetComponent<Stats_contador>().vidaActual = vidaActual;
        //DIENRO:stats.GetComponent<Stats_contador>().dineroActual = dinero;
        stats.GetComponent<Stats_contador>().dano = dano;

        //String e int no pueden ir juntos; creo una variable para obtener el dato de la puntuación
        int punt = (vidaActual*10) +
        //(dineroActual * 10) + 
        (dano*10);

        //Transformo el dato int en string (con el nombre antes establecido)
        puntuacionFinal = punt.ToString();

        //Modifico el texto UI que hay en el archivo
        //this.GetComponent<TextMeshProUGUI>().text = puntuacionFinal;
    }


    void Update()
    {
        
    }
}
