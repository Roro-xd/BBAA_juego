using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HabilidadCuracion : MonoBehaviour
{
    public float tiempoParaCurar = 2f;       // Tiempo que hay que mantener presionado
    public int cantidadCurar = 1;            // Cuánto cura
    public float cooldown = 5f;              // Tiempo de espera entre curaciones
    public float reduccionVelocidad = 0.5f;  // Reducción de velocidad durante curación

    private float tiempoPresionado = 0f;
    private bool estaCurando = false;
    private bool enCooldown = false;

    private Caminar caminar;
    private Vida vida;
    private SpriteRenderer spriteRenderer;
    private Color colorOriginal;
    private float velocidadOriginal;
    //PORFA REVISAR SI AL CAMINAR EN DIAGONAL Y AL USAR LA HABILIDAD SIGUE BLOQUEANDOSE


    //RORO: INCLUYO AQUI LA ANIMACION DE LA BARRA DE TIEMPO
    private GameObject barraHabEsp;
    Animator animBarra;


    void Start()
    {
        caminar = GetComponent<Caminar>();
        vida = GetComponent<Vida>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorOriginal = spriteRenderer.color;
        velocidadOriginal = caminar.velomov;

        vida.OnDanoRecibido += CancelarCuracion;


        barraHabEsp = GameObject.Find("VisualHabEsp");
        animBarra = barraHabEsp.GetComponent<Animator>();
    }

    void Update()
    {
        if (enCooldown) return;

        if (Input.GetKey(KeyCode.Space))
        {
            if (!estaCurando)
            {
                IniciarCuracion();
            }

            tiempoPresionado += Time.deltaTime;

            if (tiempoPresionado >= tiempoParaCurar)
            {
                vida.Curar(cantidadCurar);
                TerminarCuracion();
                StartCoroutine(Cooldown());
            }
        }
        else
        {
            if (estaCurando)
            {
                CancelarCuracion();
            }
            tiempoPresionado = 0f; // Resetea tiempo si sueltas espacio
        }
    }

    void IniciarCuracion()
    {
        estaCurando = true;
        caminar.velomov *= reduccionVelocidad;
        spriteRenderer.color = Color.yellow;
        this.GetComponent<Animator>().SetBool("siCura", true); //Activa la animación
        animBarra.SetBool("HabUsando", true);
        animBarra.SetBool("HabUsable", false);
    }

    void TerminarCuracion()
    {
        estaCurando = false;
        caminar.velomov = velocidadOriginal;
        spriteRenderer.color = colorOriginal;
        this.GetComponent<Animator>().SetBool("siCura", false);//termina la animación
    }

    void CancelarCuracion()
    {
        if (estaCurando)
        {
            Debug.Log("Curacion cancelada por dano recibido.");
            this.GetComponent<Animator>().SetBool("siCura", false);//cancela la animación de curado

            TerminarCuracion();
            tiempoPresionado = 0f;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        enCooldown = true;
        animBarra.SetBool("HabCooldown", true);
        yield return new WaitForSeconds(cooldown);
        enCooldown = false;
        animBarra.SetBool("HabUsable", true);

    }

}
