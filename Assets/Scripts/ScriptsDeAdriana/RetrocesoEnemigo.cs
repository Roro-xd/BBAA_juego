using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RetrocesoEnemigo : MonoBehaviour
{
    //Este es un Script para que cuando el enemigo reciba daño, retroceda


    public int vidaActual; //la vida del enemigo en cada momento
    public int vidaRefencia;// la vida contra la que se compara para saber que ha recibido daño

    public GameObject player;
    public bool jugadorDerecha; //si el jugador está a la derecha
    public bool jugadorEncima;// si el jugador está por encima

    public float distancia = 1f; //la distancia a la que llega el restroceso

    public bool retroceder = false;


    // Start is called before the first frame update

    void Awake()
    {
        vidaActual = this.GetComponent<VidaEnemigo>().vidaActual; //consigue la vida actual del enemigo
    }

    void Start()
    {

        vidaRefencia = vidaActual; //la vuelve la vida de referencia
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()

    {
        vidaActual = this.GetComponent<VidaEnemigo>().vidaActual;//actualiza la vida actual
        if (vidaActual < vidaRefencia)
        {
            Retroceso();
            vidaRefencia = vidaActual;
        }


        /* //detecta dónde está el jugador relativo al enemigo
         if (player.transform.position.y < transform.position.y) { jugadorEncima = false; }
         if (player.transform.position.y > transform.position.y) { jugadorEncima = true; }
         if (player.transform.position.x < transform.position.x) { jugadorDerecha = false; }
         if (player.transform.position.x > transform.position.x) { jugadorEncima = true; }*/

        if (retroceder == true) { Retroceso(); }
    }

    public void Retroceso()
    {
        if (jugadorDerecha == true) { transform.Translate(transform.position.x - distancia * Time.deltaTime, transform.position.y, 0); }
        if (jugadorDerecha == false) { transform.Translate(transform.position.x + distancia * Time.deltaTime, transform.position.y, 0); }
        if (jugadorEncima == true) { transform.Translate(transform.position.x, transform.position.y - distancia * Time.deltaTime, 0); }
        if (jugadorEncima == false) { transform.Translate(transform.position.x, transform.position.y + distancia * Time.deltaTime, 0); }
        retroceder = false;
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
