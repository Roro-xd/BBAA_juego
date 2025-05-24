using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurroBossController : MonoBehaviour
{
    public Transform jugador;
    public float rangoDeteccion = 10f;

    [Header("Movimiento Wander")]
    public Vector2 areaWanderMin;
    public Vector2 areaWanderMax;
    public float velocidadMovimiento = 2f;
    public float tiempoCambioDireccionMin = 2f;
    public float tiempoCambioDireccionMax = 5f;

    [Header("Ataque")]
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreRafagas = 5f;
    public int balasPorRafaga = 5;
    public float tiempoEntreBalas = 0.2f;
    public float velocidadProyectil = 10f;
    public float anguloRafaga = 45f;

    [Header("Señales Visuales")]
    public SpriteRenderer spriteRenderer;
    public Color colorNormal = Color.white;
    public Color colorAdvertencia = Color.red;
    public float tiempoParpadeo = 0.5f;
    public float duracionVibracion = 0.3f;
    public float intensidadVibracion = 0.1f;

    private Vector2 direccionMovimiento;
    private float tiempoSiguienteCambioDireccion;
    private float tiempoSiguienteRafaga;

    private bool estaDisparando = false;

    private Vector3 posicionBase;
    private Vector3 offsetVibracion = Vector3.zero;

    private void Start()
    {
        CambiarDireccion();
        posicionBase = transform.position;
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        tiempoSiguienteRafaga = Time.time + 1f;  // Primera ráfaga pronto
    }

    private void Update()
    {
        Debug.Log("Update ejecutado");

        if (jugador == null)
        {
            Debug.LogWarning("Jugador no asignado!");
            return;
        }

        if (!estaDisparando)
            Mover();

        Debug.Log($"Posición base: {posicionBase}, Dirección: {direccionMovimiento}");

        transform.position = posicionBase + offsetVibracion;

        if (jugador.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);

        Debug.Log($"Esta disparando: {estaDisparando}, Time.time: {Time.time}, tiempoSiguienteRafaga: {tiempoSiguienteRafaga}");

        if (!estaDisparando && Time.time >= tiempoSiguienteRafaga)
        {
            Debug.Log("Iniciando Coroutine PrepararYDisparar");
            StartCoroutine(PrepararYDisparar());
        }
    }

    private void Mover()
    {
        Debug.Log("Mover ejecutado");

        if (Time.time >= tiempoSiguienteCambioDireccion)
        {
            CambiarDireccion();
        }

        Vector2 nuevaPos = (Vector2)posicionBase + direccionMovimiento * velocidadMovimiento * Time.deltaTime;

        // Limitar a área wander
        nuevaPos.x = Mathf.Clamp(nuevaPos.x, areaWanderMin.x, areaWanderMax.x);
        nuevaPos.y = Mathf.Clamp(nuevaPos.y, areaWanderMin.y, areaWanderMax.y);

        Debug.Log($"Mover - Pos base: {posicionBase}, Dir: {direccionMovimiento}, Nueva pos: {nuevaPos}");

        posicionBase = nuevaPos;
    }

    private void CambiarDireccion()
    {
        direccionMovimiento = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;

        Debug.Log($"Nueva dirección: {direccionMovimiento}");

        tiempoSiguienteCambioDireccion = Time.time + Random.Range(tiempoCambioDireccionMin, tiempoCambioDireccionMax);
    }

    private IEnumerator PrepararYDisparar()
    {
        estaDisparando = true;

        Debug.Log("PrepararYDisparar iniciado");

        // Parpadeo y vibracion antes de disparar
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

        Debug.Log("Preparación terminada, disparando ráfaga");
        yield return StartCoroutine(DispararRafaga());

        tiempoSiguienteRafaga = Time.time + tiempoEntreRafagas;
        estaDisparando = false;
    }

    private void Vibrar()
    {
        float offsetX = Random.Range(-intensidadVibracion, intensidadVibracion);
        float offsetY = Random.Range(-intensidadVibracion, intensidadVibracion);
        offsetVibracion = new Vector3(offsetX, offsetY, 0);
    }

   private IEnumerator DispararRafaga()
{
    Debug.Log("Disparando ráfaga con " + balasPorRafaga + " balas");

    // Dirección base desde el punto de disparo hacia el jugador
    Vector2 direccionBase = (jugador.position - puntoDisparo.position).normalized;

    // Convertir dirección base a ángulo en grados
    float anguloBase = Mathf.Atan2(direccionBase.y, direccionBase.x) * Mathf.Rad2Deg;

    float anguloInicial = anguloBase - anguloRafaga / 2f;
    float anguloIncremento = anguloRafaga / (balasPorRafaga - 1);

    for (int i = 0; i < balasPorRafaga; i++)
    {
        float anguloDisparo = anguloInicial + i * anguloIncremento;
        Vector2 direccion = Quaternion.Euler(0, 0, anguloDisparo) * Vector2.right;

        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);

        Proyectil p = proyectil.GetComponent<Proyectil>();
        if (p != null)
        {
            p.direccion = direccion.normalized;
            p.velocidad = velocidadProyectil;
        }
        else
        {
            Debug.LogWarning("El prefab del proyectil no tiene el script Proyectil!");
        }

        yield return new WaitForSeconds(tiempoEntreBalas);
    }
}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 1f, 0f, 0.25f);

        Vector3 centro = new Vector3(
            (areaWanderMin.x + areaWanderMax.x) / 2f,
            (areaWanderMin.y + areaWanderMax.y) / 2f,
            transform.position.z);

        Vector3 tamaño = new Vector3(
            Mathf.Abs(areaWanderMax.x - areaWanderMin.x),
            Mathf.Abs(areaWanderMax.y - areaWanderMin.y),
            0f);

        Gizmos.DrawCube(centro, tamaño);
    }
}