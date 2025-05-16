using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar : MonoBehaviour
{
    public float velomov = 5f;
    private Vector2 movimiento;

    public bool vaIzq = false;
    public bool seMueve = false;

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
        if (movimiento.x < 0) {vaIzq = true; this.GetComponent<SpriteRenderer>().flipX = true;} 
        else if (movimiento.x > 0){vaIzq = false; this.GetComponent<SpriteRenderer>().flipX = false;}
        
        //detecta si el personaje se está moviendo
        if (movimiento == new Vector2(0, 0)) {seMueve = false;}
        else {seMueve = true;}

        //activa la animación de caminado
        if (seMueve==true) {this.GetComponent<Animator>().SetBool("siCamina",true) ;}
        else {this.GetComponent<Animator>().SetBool("siCamina",false) ;}   


    }

    void FixedUpdate()
    {          

        rb.velocity = movimiento * velomov;


    }
    
}
