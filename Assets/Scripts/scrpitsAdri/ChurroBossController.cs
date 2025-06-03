using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurroBossController : MonoBehaviour
{
    public Transform jugador;
    public float velocidadMovimiento = 2f;

    [Header("Movimiento Wander")]
    public Vector2 areaWanderMin;
    public Vector2 areaWanderMax;
    public float tiempoCambioDireccionMin = 2f;
    public float tiempoCambioDireccionMax = 5f;

    [Header("Ataque Primera Fase")]
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreRafagas = 5f;
    public int balasPorRafaga = 5;
    public float tiempoEntreBalas = 0.2f;
    public float velocidadProyectil = 10f;
    public float anguloRafaga = 45f;

    [Header("Ataque Segunda Fase")]
    public GameObject balaAreaPrefab; // Bala para ataque en área
    public GameObject enemigoPrefab;  // Enemigos que spawneará alrededor
    public int enemigosPorSpawn = 3;

    // Variable para controlar la cantidad de balas en área
    public int cantidadBalasArea = 8;

    [Header("Señales Visuales")]
    public SpriteRenderer spriteRenderer;
    public Color colorNormal = Color.white;
    public Color colorAdvertencia = Color.red;
    public float tiempoParpadeo = 0.5f;
    public float intensidadVibracion = 0.1f;

    [Header("Vida")]
    public int vidaMaxima = 100;
    private int vidaActual;

    private Vector2 direccionMovimiento;
    private float tiempoSiguienteCambioDireccion;
    private float tiempoSiguienteRafaga;
    private Vector3 posicionBase;
    private Vector3 offsetVibracion = Vector3.zero;
    private bool estaDisparando = false;
    private bool segundaFaseActiva = false;

    private Collider2D jefeCollider;



    //Cagadas de Rocío
    private bool modoAtaque = false;
    public GameObject panelChurroBoss;

    //cosas de animación
    public bool animActiva = false; //animación de ataque en marcha
     

    private void Start()
    {
        vidaActual = vidaMaxima;
        posicionBase = transform.position;
        CambiarDireccion();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        jefeCollider = GetComponent<Collider2D>();

        tiempoSiguienteRafaga = Time.time + 1f;
    }

    private void Update()
    {
        if (panelChurroBoss.activeSelf)
        {
            modoAtaque = true;
        }
        if (modoAtaque == false) return;
        if (jugador == null) return;

        if (!segundaFaseActiva)
        {
            if (!estaDisparando)
                Mover();

            if (!estaDisparando && Time.time >= tiempoSiguienteRafaga)
                StartCoroutine(PrepararYDisparar_PrimeraFase());
        }
        else
        {
            if (!estaDisparando)
                Mover();

            if (!estaDisparando && Time.time >= tiempoSiguienteRafaga)
                StartCoroutine(PrepararYDisparar_SegundaFase());
        }

        transform.position = posicionBase + offsetVibracion;

        if (jugador.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Mover()
    {
        if (Time.time >= tiempoSiguienteCambioDireccion)
            CambiarDireccion();

        Vector2 nuevaPos = (Vector2)posicionBase + direccionMovimiento * velocidadMovimiento * Time.deltaTime;
        nuevaPos.x = Mathf.Clamp(nuevaPos.x, areaWanderMin.x-8f, areaWanderMax.x-8f);
        nuevaPos.y = Mathf.Clamp(nuevaPos.y, areaWanderMin.y-65f, areaWanderMax.y-65f);
        posicionBase = nuevaPos;

        this.GetComponent<Animator>().SetBool("siCamina", true);//llama a la animación de caminado
        AudioManager.Instance.PlayOtros("caminadoMedio");
        
    }

    private void CambiarDireccion()
    {
        direccionMovimiento = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        tiempoSiguienteCambioDireccion = Time.time + Random.Range(tiempoCambioDireccionMin, tiempoCambioDireccionMax);
        //AudioManager.Instance.PlayOtros("caminadoMedio");
    }

    private IEnumerator PrepararYDisparar_PrimeraFase()
    {
        estaDisparando = true;

        float timer = 0f;
        while (timer < tiempoParpadeo)
        {
            spriteRenderer.color = Color.Lerp(colorNormal, colorAdvertencia, Mathf.PingPong(timer * 10f, 1));
            Vibrar();
            timer += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = colorNormal;
        offsetVibracion = Vector3.zero;

        yield return StartCoroutine(DispararRafaga());

        tiempoSiguienteRafaga = Time.time + tiempoEntreRafagas;
        estaDisparando = false;
    }

    private IEnumerator PrepararYDisparar_SegundaFase()
    {
        estaDisparando = true;

        float timer = 0f;
        while (timer < tiempoParpadeo)
        {
            spriteRenderer.color = Color.Lerp(colorNormal, colorAdvertencia, Mathf.PingPong(timer * 10f, 1));
            Vibrar();
            timer += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = colorNormal;
        offsetVibracion = Vector3.zero;

        yield return StartCoroutine(DispararArea());

        tiempoSiguienteRafaga = Time.time + tiempoEntreRafagas;
        estaDisparando = false;
    }

    private void Vibrar()
    {
        if (animActiva == false)//llama a la animación de ataque
        {
            this.GetComponent<Animator>().SetBool("siAtaca", true);
            animActiva = true;
            StartCoroutine(AnimAtaque());
        }


        float offsetX = Random.Range(-intensidadVibracion, intensidadVibracion);
        float offsetY = Random.Range(-intensidadVibracion, intensidadVibracion);
        offsetVibracion = new Vector3(offsetX, offsetY, 0);
    }

    private IEnumerator DispararRafaga()
    {
        Vector2 direccionBase = (jugador.position - puntoDisparo.position).normalized;
        float anguloBase = Mathf.Atan2(direccionBase.y, direccionBase.x) * Mathf.Rad2Deg;
        float anguloInicial = anguloBase - anguloRafaga / 2f;
        float anguloIncremento = anguloRafaga / (balasPorRafaga - 1);

        for (int i = 0; i < balasPorRafaga; i++)
        {
            AudioManager.Instance.PlaySFX("AtaqueChurro");
            float angulo = anguloInicial + i * anguloIncremento;
            Vector2 dir = Quaternion.Euler(0, 0, angulo) * Vector2.right;
            GameObject bala = Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);

            Collider2D balaCollider = bala.GetComponent<Collider2D>();
            if (balaCollider != null && jefeCollider != null)
            {
                Physics2D.IgnoreCollision(balaCollider, jefeCollider);
            }

            Proyectil p = bala.GetComponent<Proyectil>();
            if (p != null)
            {
                p.direccion = dir.normalized;
                p.velocidad = velocidadProyectil;
            }

            yield return new WaitForSeconds(tiempoEntreBalas);
        }
    }

    private IEnumerator DispararArea()
    {
        Debug.Log("DispararArea iniciado");

        int balasArea = cantidadBalasArea;
        float anguloActual = 0f;
        float incrementoAngulo = 15f; // ángulo que girará cada bala (ajusta para más o menos espiral)
        float delayEntreBalas = 0.1f; // tiempo entre disparos para efecto visible

        for (int i = 0; i < balasArea; i++)
        {
            AudioManager.Instance.PlaySFX("AtaqueChurro");
            Vector2 dir = Quaternion.Euler(0, 0, anguloActual) * Vector2.right;
            GameObject bala = Instantiate(balaAreaPrefab, puntoDisparo.position, Quaternion.Euler(0, 0, anguloActual));
            Debug.Log("Bala area espiral instanciada en ángulo: " + anguloActual);

            Collider2D balaCollider = bala.GetComponent<Collider2D>();
            if (balaCollider != null && jefeCollider != null)
            {
                Physics2D.IgnoreCollision(balaCollider, jefeCollider);
            }

            // Ignorar colisión entre balas área
            Collider2D[] colisionadoresBalas = bala.GetComponents<Collider2D>();
            foreach (var balaCol in colisionadoresBalas)
            {
                Collider2D[] balasExistentes = FindObjectsOfType<Collider2D>();
                foreach (var col in balasExistentes)
                {
                    if (col.gameObject.CompareTag("BalaArea") && col != balaCol)
                    {
                        Physics2D.IgnoreCollision(balaCol, col);
                    }
                }
            }

            Proyectil p = bala.GetComponent<Proyectil>();
            if (p != null)
            {
                p.direccion = dir.normalized;
                p.velocidad = velocidadProyectil;
            }
            else
            {
                Debug.LogWarning("Proyectil no encontrado en balaAreaPrefab");
            }

            anguloActual += incrementoAngulo;
            if (anguloActual >= 360f)
                anguloActual -= 360f;

            yield return new WaitForSeconds(delayEntreBalas);
        }

        SpawnEnemigosAleatorios(enemigosPorSpawn);
    }
    private void SpawnEnemigosAleatorios(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector2 posicionSpawn = (Vector2)transform.position + Random.insideUnitCircle * 3f;
            Instantiate(enemigoPrefab, posicionSpawn, Quaternion.identity);
        }
    }

    // Método para que el jefe reciba daño y active segunda fase automáticamente
    public void RecibeDano(int cantidad)
    {
        vidaActual -= cantidad;

        if (!segundaFaseActiva && vidaActual <= vidaMaxima / 2)
        {
            ActivarSegundaFase();
        }

        if (vidaActual <= 0)
        {
            // Aquí lógica para la muerte del jefe (animación, desactivar, etc)
            Destroy(gameObject);
        }
    }

    private void ActivarSegundaFase()
    {
        segundaFaseActiva = true;
        // Puedes agregar efectos, sonidos o animaciones aquí para la segunda fase
    }

    IEnumerator AnimAtaque() //tiempo de animación de ataque
    {
        yield return new WaitForSeconds(1.8f);
        this.GetComponent<Animator>().SetBool("siAtaca", false);
        animActiva = false;
    }

}