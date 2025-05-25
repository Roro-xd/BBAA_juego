using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stats_contador : MonoBehaviour
{

    //LLAMO A CADA STAT
    //Llamo a vida <3
    public int vidaActual;

    /*Llamo al dinero B)
    private int dineroActual;*/

    //Llamo a la velocidad ¬¬
    public float velMov;

    //Llamo a la velocidad de ataque ¬* ¬*
    public float velAtk;

    //Llamo al daño de ataque ¬* ¬*
    public int dano;

    //Los scripts pertenecen al player
    private GameObject player;



    //LLAMO A LOS TEXTOS QUE VAN A PONER EL VALOR EN EL MENÚ
    public GameObject textoDano;
    public GameObject textoVel;
    public GameObject textoVelAtk;





    void Start()
    {
        player = GameObject.FindWithTag("Player");

        player.GetComponent<Vida>().vidaActual = vidaActual;
        //DIENRO:player.GetComponent<Vida>().vidaActual = vidaActual;
        velMov= player.GetComponent<Caminar>().velomov;
        velAtk = player.GetComponent<AtaqueMelee>().tiempoUltimoAtaque;
        dano = player.GetComponent<AtaqueMelee>().dano;

    }

    // Update is called once per frame
    void Update()
    {
        textoDano.GetComponent<TextMeshProUGUI>().text = dano.ToString();
        textoVel.GetComponent<TextMeshProUGUI>().text = velMov.ToString();
        textoVelAtk.GetComponent<TextMeshProUGUI>().text = velAtk.ToString();
    }
}
