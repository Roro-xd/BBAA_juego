using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMelee : MonoBehaviour
{
    public Transform puntoAtaque;
    public float radioAtaque = 2f;
    public float anguloCono = 60f;
    public LayerMask capaEnemigos;
    public int dano = 1;

    public float cooldownBase = 1f;
    private float cooldownActual;
    public float tiempoUltimoAtaque = -999f;

    private Camera camara;
    private Animator animator;
    private CharacterStats stats;

    bool siEsperaAtaque = false;
    public bool siPuedoAtacar = true;
    public bool siAcierta = false;
    public bool sePuedeAtacar = true; 

    void Start()
    {
        camara = Camera.main;
        animator = GetComponent<Animator>();
        cooldownActual = cooldownBase;

        stats = GetComponent<CharacterStats>();
        if (stats != null)
        {
            cooldownBase = 1f / stats.attackSpeed.TotalValue;
            cooldownActual = cooldownBase;
            stats.OnStatChanged += OnStatChanged;
        }

        // **Usando Vida.Instance para obtener el daño**
        if (Vida.Instance != null)
        {
            Vida.Instance.dano = Mathf.RoundToInt(stats.damage.TotalValue);
        }
    }

    void OnDestroy()
    {
        if (stats != null)
            stats.OnStatChanged -= OnStatChanged;
    }

    void OnStatChanged(StatType type, float newValue)
    {
        switch (type)
        {
            case StatType.Damage:
                if (Vida.Instance != null)
                {
                    Vida.Instance.dano = Mathf.RoundToInt(newValue);
                    Debug.Log("Daño actualizado: " + Vida.Instance.dano);
                }
                break;

            case StatType.AttackSpeed:
                cooldownBase = 1f / newValue;
                cooldownActual = cooldownBase;
                Debug.Log("Nuevo cooldown base: " + cooldownBase);
                break;
        }
    }

    void Update()
    {
        if (!sePuedeAtacar) return;

        if (Input.GetMouseButtonDown(0) && Time.time >= tiempoUltimoAtaque + cooldownActual)
        {
            siPuedoAtacar = true;
            Atacar();
            tiempoUltimoAtaque = Time.time;

            if (animator != null)
            {
                animator.SetBool("siAtaca", true);
                siEsperaAtaque = true;
                StartCoroutine(AnimacionAtac());
            }
        }

        if (Time.time >= tiempoUltimoAtaque + cooldownActual)
            siPuedoAtacar = true;
        else
            siPuedoAtacar = false;
    }

    void Atacar()
    {
        if (Vida.Instance == null) return; // Aseguramos que Vida.Instance existe

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
                    vidaEnemigo.RecibirDano(Vida.Instance.dano); // Usamos Vida.Instance
                }
                else
                {
                    var jefe = enemigo.GetComponent<VidaJefe>();
                    if (jefe != null)
                    {
                        jefe.RecibirDano(Vida.Instance.dano);
                    }
                }

                enemigo.GetComponent<Persecución>().siHerido = true;
                siAcierta = true;

                Debug.Log("Golpe");
            }
        }
    }
        IEnumerator AnimacionAtac()
        {
            AudioManager.Instance.PlaySFX("BunAtaca");
            yield return new WaitForSeconds(0.3f);
            siEsperaAtaque = false;
            animator.SetBool("siAtaca", false);
            siAcierta = false;
        }
    public void SubeAtaque(int cantidad)
    {
        if (Vida.Instance != null)
        {
            Vida.Instance.dano += cantidad;
            Debug.Log("Tu ataque ahora hace esta cantidad de daño: " + Vida.Instance.dano);
        }
    }
}
