using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMelee : MonoBehaviour
{
    public Transform puntoAtaque;
    public float radioAtaque = 2f;
    public float anguloCono = 60f;
    public int dano = 1;
    public LayerMask capaEnemigos;

    public float cooldownBase = 1f;  // Cooldown inicial
    private float cooldownActual;
    public float tiempoUltimoAtaque = -999f;

    private Camera camara;
    private Animator animator;

    bool siEsperaAtaque = false;
    public bool siPuedoAtacar = true;
    public bool siAcierta = false;
    void Start()
    {
        camara = Camera.main;
        animator = GetComponent<Animator>();
        cooldownActual = cooldownBase;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= tiempoUltimoAtaque + cooldownActual)
        {
            siPuedoAtacar = true;
            Atacar();
            tiempoUltimoAtaque = Time.time;

            if (animator != null)
            {

            }

            if (siEsperaAtaque == false)
            {//Llama a la animación de ataque solo cuando se ataca
                animator.SetBool("siAtaca", true);
                siEsperaAtaque = true;
                StartCoroutine(AnimacionAtac());
            }
        }

        if (Time.time >= tiempoUltimoAtaque + cooldownActual) { siPuedoAtacar = true; } else { siPuedoAtacar = false; } //determina si está en cooldown o no
    }

    void Atacar()
{
    Vector3 posicionMouse = camara.ScreenToWorldPoint(Input.mousePosition);
    Vector2 direccionAtaque = (posicionMouse - puntoAtaque.position).normalized;

    Collider2D[] enemigosCerca = Physics2D.OverlapCircleAll(puntoAtaque.position, radioAtaque, capaEnemigos);

    foreach (Collider2D enemigo in enemigosCerca)
    {
        Vector2 direccionAlEnemigo = (Vector2)(enemigo.transform.position - puntoAtaque.position);
        float anguloEntre = Vector2.Angle(direccionAtaque, direccionAlEnemigo);

        if (anguloEntre <= anguloCono / 2f)
        {
            var vidaEnemigo = enemigo.GetComponent<VidaEnemigo>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.RecibirDano(dano);
            }
            else
            {
                var jefe = enemigo.GetComponent<VidaJefe>();
                if (jefe != null)
                {
                    jefe.RecibirDano(dano);
                }
            }

            enemigo.GetComponent<Persecución>().siHerido = true;
            siAcierta = true;

            Debug.Log("Golpe");
        }
    }
}


    public void ReducirCooldown(float cantidad)
    {
        cooldownActual -= cantidad;
        cooldownActual = Mathf.Clamp(cooldownActual, 0.1f, cooldownBase); // no menos de 0.1 ni más que base
        Debug.Log("Cooldown reducido a: " + cooldownActual);
    }

    public void ResetearCooldown()
    {
        cooldownActual = cooldownBase;
        Debug.Log("Cooldown reseteado a base: " + cooldownBase);
    }

    private void OnDrawGizmosSelected()
    {
        if (puntoAtaque == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(puntoAtaque.position, radioAtaque);

        if (camara != null && Application.isPlaying)
        {
            Vector3 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direccion = (mousePos - puntoAtaque.position).normalized;

            float halfAngle = anguloCono / 2f;

            Vector2 izquierda = Quaternion.Euler(0, 0, -halfAngle) * direccion;
            Vector2 derecha = Quaternion.Euler(0, 0, halfAngle) * direccion;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(puntoAtaque.position, puntoAtaque.position + (Vector3)izquierda * radioAtaque);
            Gizmos.DrawLine(puntoAtaque.position, puntoAtaque.position + (Vector3)derecha * radioAtaque);
        }
    }



    IEnumerator AnimacionAtac()
    {
        yield return new WaitForSeconds(0.3f);
        siEsperaAtaque = false;
        animator.SetBool("siAtaca", false);
        siAcierta = false;
    }

    public void SubeAtaque(int cantidad)
    {
        dano += cantidad;
        Debug.Log("Tu ataque ahora hace esta cantidad de daño:" + dano);
    }
}
