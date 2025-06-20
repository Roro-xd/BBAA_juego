using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stats_contador : MonoBehaviour
{

    //LLAMO A CADA STAT
    //Llamo a vida <3
    //public int vidaActual;

    //Llamo al dinero B)
    //public int dineroActual;

    //Llamo a la velocidad ¬¬
    //public float velMov;

    //Llamo a la velocidad de ataque ¬* ¬*
    public float velAtk;

    //Llamo al daño de ataque ¬* ¬*
    //public int dano;

    //Los scripts pertenecen al player
    private GameObject player;



    //LLAMO A LOS TEXTOS QUE VAN A PONER EL VALOR EN EL MENÚ
    public GameObject textoDano;
    public GameObject textoVel;
    public GameObject textoVelAtk;





    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (Vida.Instance != null)
        {
            Vida.Instance.monedas = 0;
            Vida.Instance.dano = 1;
        }

        //COGER VALORES DE SUS SCRIPTS ORIGINALES
        //vidaActual = Vida.Instance.vidaActual;
        //dineroActual = Vida.Instance.monedas;
        //velMov = Vida.Instance.velomov;
        velAtk = player.GetComponent<AtaqueMelee>().tiempoUltimoAtaque;
        //dano = Vida.Instance.dano;

    }



    void Update()
    {
        //Como la velocidad de ataque va con cifras un poco etrañas, las mappeo para que visualmente se entiendan mejor
        float velAtkMap = Map(velAtk, -999, 0, 1, 10);
        velAtkMap = (int)velAtkMap;

        //Establezco los valores con sus textos en el menú
        textoDano.GetComponent<TextMeshProUGUI>().text = Vida.Instance.dano.ToString();
        textoVel.GetComponent<TextMeshProUGUI>().text = Vida.Instance.velomov.ToString();
        textoVelAtk.GetComponent<TextMeshProUGUI>().text = velAtkMap.ToString();
    }

    //Forma de hacer el mappeo
    static public float Map(float value, float inicioA, float finalA, float inicioB, float finalB)
    {
        return inicioB + (finalB - inicioB) * ((value - inicioA) / (finalA - inicioA));
    }
}
