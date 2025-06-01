using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public static Vida Instance; // ← Ahora está definida correctamente

    public int vidaBase = 4;
    public int vidaMax = 10;
    public int vidaActual;
    public int dano = 1; // ← Añadimos daño para compatibilidad con AtaqueMelee
    private CharacterStats stats;

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
        stats = GetComponent<CharacterStats>();
        if (stats != null)
        {
            vidaBase = (int)stats.health.TotalValue;
            vidaActual = vidaBase;
            dano = Mathf.RoundToInt(stats.damage.TotalValue); // ← Inicializamos daño
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

    public void SubeAtaque(int cantidad)
    {
        dano += cantidad; // ← Ahora puedes modificar el daño correctamente
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