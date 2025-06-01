using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar : MonoBehaviour
{
    public float velomov = 5f;
    private Vector2 movimiento;
    private CharacterStats stats;

    public bool vaIzq = false;
    public bool seMueve = false;

    public bool sePuedeMover = true; 
    private Rigidbody2D rb;

    private bool modoAtaque = false;
    public GameObject panelChurroBoss;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
        if (stats != null)
        {
            velomov = stats.moveSpeed.TotalValue;
            stats.OnStatChanged += OnStatChanged;
        }
    }
    void OnDestroy()
    {
        if (stats != null)
            stats.OnStatChanged -= OnStatChanged;
    }
    void OnStatChanged(StatType type, float newValue)
    {
        if (type == StatType.MoveSpeed)
        {
            velomov = newValue;
            Debug.Log("Velocidad actualizada a: " + velomov);
        }
    }

    void Update()
    {
        if (!sePuedeMover)
        {
            // No permitimos movimiento ni animación caminando
            movimiento = Vector2.zero;
            seMueve = false;
            this.GetComponent<Animator>().SetBool("siCamina", false);
            return;
        }

        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
        movimiento = movimiento.normalized;

        // Flipping del sprite según dirección X
        if (movimiento.x < 0)
        {
            vaIzq = true;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movimiento.x > 0)
        {
            vaIzq = false;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        // Detecta si el personaje se está moviendo
        seMueve = movimiento != Vector2.zero;

        // Activa la animación de caminar
        this.GetComponent<Animator>().SetBool("siCamina", seMueve);

        // LOS SONIDOS DE CAMINADO FUNCIONAN A LA INVERSA
        /*if (!seMueve)
        {
            if (velomov >= 1 && velomov < 2)
            {
                AudioManager.Instance.PlayOtros("caminadoLento");
            }
            else if (velomov >= 2 && velomov < 3)
            {
                AudioManager.Instance.PlayOtros("caminadoMedio");
            }
            else if (velomov >= 3)
            {
                AudioManager.Instance.PlayOtros("caminadoRapido");
            }
        }*/
    }

    void FixedUpdate()
    {
        if (sePuedeMover)
        {
            rb.velocity = movimiento * velomov;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void AumentaVelocidad(float cantidad)
    {
        velomov += cantidad;
        Debug.Log("Ha subido la velocidad en " + cantidad);
    }
}