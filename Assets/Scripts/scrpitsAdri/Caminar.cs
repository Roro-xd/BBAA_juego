using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar : MonoBehaviour
{
    private Vector2 movimiento;
    private Rigidbody2D rb;

    public bool vaIzq = false;
    public bool seMueve = false;
    public bool sePuedeMover = true;
    public GameObject panelChurroBoss;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (Vida.Instance != null)
        {
            Vida.Instance.velomov = 2f;
        }
    }

    void Update()
    {
        if (!sePuedeMover)
        {
            movimiento = Vector2.zero;
            seMueve = false;
            GetComponent<Animator>().SetBool("siCamina", false);
            return;
        }

        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
        movimiento = movimiento.normalized;

        // Flipping del sprite según dirección X
        if (movimiento.x < 0)
        {
            vaIzq = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movimiento.x > 0)
        {
            vaIzq = false;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        seMueve = movimiento != Vector2.zero;

        GetComponent<Animator>().SetBool("siCamina", seMueve);
    }

    void FixedUpdate()
    {
        if (sePuedeMover && Vida.Instance != null)
        {
            rb.velocity = movimiento * Vida.Instance.velomov; // ← Ahora usa la velocidad del Singleton
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
