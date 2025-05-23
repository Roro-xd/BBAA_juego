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

    public float distancia; //la distancia a la que llega el restroceso


    // Start is called before the first frame update
    void Start()
    {
        vidaActual = this.GetComponent<VidaEnemigo>().vidaActual; //consigue la vida actual del enemigo
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
    }

    public void Retroceso()
    {
        if (jugadorDerecha == true) { transform.Translate(transform.position.x - distancia, transform.position.y, 0); }
        if (jugadorDerecha==false){ transform.Translate(transform.position.x+distancia,transform.position.y,0); }
    }
}
