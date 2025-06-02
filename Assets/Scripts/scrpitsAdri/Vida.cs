using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public static Vida Instance;

    public int vidaBase = 4;
    public int vidaMax = 10;
    public int vidaActual;
    public int dano = 1; // ← Ahora daño es parte del Singleton
    public float velomov = 2f; // ← Ahora la velocidad es parte del Singleton
    public int nivelChurro = 0; // ← Ahora los niveles de relaciones son parte del Singleton
    public int nivelNapo = 0;
    public int nivelYori = 0;
    public int monedas = 0; // ← Ahora las monedas son parte del Singleton
    public float cooldownActual = 1f;


    public event Action OnDanoRecibido;

    bool siEsperamos = false;
    bool siEsperaDano = false;

    void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }
}

    void Start()
    {
         if (Vida.Instance != null)
    {
        Debug.Log("Vida inicializada con: " + vidaActual);
        Debug.Log("Ataque inicial: " + dano);
        Debug.Log("Velocidad inicial: " + velomov);
    }

    }

    public void RecibeDano(int cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaBase);
        Debug.Log("Vida actual: " + vidaActual);
        OnDanoRecibido?.Invoke();
        
        if (vidaActual <= 0)
        {
            Muerte();
        }

        if (!siEsperaDano)
        {
            siEsperaDano = true;
            AnimacionHerido();
        }
    }

    public void Curar(int cantidad)
    {
        vidaActual += cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaBase);
        Debug.Log("Curado. Vida actual: " + vidaActual);
    }

    public void AumentoVidaMax(int cantidad, bool curarFull = true)
    {
        vidaBase += cantidad;
        if (curarFull)
            vidaActual = vidaBase;

        Debug.Log("Nueva vida máxima: " + vidaBase + " | Vida actual: " + vidaActual);
    }

    public void AumentoVelocidad(float cantidad)
    {
        velomov += cantidad;
        Debug.Log("Velocidad aumentada en " + cantidad + ". Nueva velocidad: " + velomov);
    }

    public void SubeAtaque(int cantidad)
    {
        dano += cantidad;
        Debug.Log("Tu ataque ahora hace esta cantidad de daño: " + dano);
    }

    private void Muerte()
    {
        Debug.Log("El jugador ha muerto.");
        AudioManager.Instance.PlaySFX("MuerteBun");

        if (!siEsperamos)
        {
            StartCoroutine(TiempoEspera());
            siEsperamos = true;
            GetComponent<Animator>().SetBool("siMuere", true);
            GetComponent<Caminar>().sePuedeMover = false;
            StartCoroutine(LlevarADerrota());
        }
    }

    IEnumerator TiempoEspera()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
        siEsperamos = false;
    }

    void AnimacionHerido()
    {
        if (!siEsperamos)
        {
            GetComponent<Animator>().SetBool("siHerido", true);
            AudioManager.Instance.PlaySFX("DanoBun");
            StartCoroutine(TiempoAnim());
        }
    }

    IEnumerator TiempoAnim()
    {
        yield return new WaitForSeconds(0.4f);
        GetComponent<Animator>().SetBool("siHerido", false);
        siEsperaDano = false;
    }

    IEnumerator LlevarADerrota()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Derrota");
    }

    public int GetCurrentHealth() => vidaActual;
    public int GetMaxHealth() => vidaBase;
}
