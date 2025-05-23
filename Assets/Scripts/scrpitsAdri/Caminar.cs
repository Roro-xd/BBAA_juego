using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar : MonoBehaviour
{
    public float velomov = 5f;
    private Vector2 movimiento;

    public bool vaIzq = false;
    public bool seMueve = false;

    public bool sePuedeMover = true; //dicta si se puede mover

    private Rigidbody2D rb;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
        movimiento = movimiento.normalized;

        //flipea en dirección 
        if (movimiento.x < 0) { vaIzq = true; this.GetComponent<SpriteRenderer>().flipX = true; }
        else if (movimiento.x > 0) { vaIzq = false; this.GetComponent<SpriteRenderer>().flipX = false; }

        //detecta si el personaje se está moviendo
        if (movimiento == Vector2.zero) { seMueve = false; }
        else { seMueve = true; }

        //activa la animación de caminado
        this.GetComponent<Animator>().SetBool("siCamina", seMueve);


        if (sePuedeMover == false) { rb = null; } // cancela el rigidbody para anular el movimiento 




    }
    void FixedUpdate()
    {

        // Permite mover al personaje incluso con la habilidad activa
        rb.velocity = movimiento * velomov;

    }

    public void AumentaVelocidad(float cantidad)
    {
        velomov += cantidad; 
        Debug.Log("Ha subido la velocidad en"+ cantidad);
    }
    
}
