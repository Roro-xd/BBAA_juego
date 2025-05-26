using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Vida : MonoBehaviour
{
    //OLA SOY RORO YO PONDRÍA vidaBase = 4; y crearía un vidaMax = 10; ADIOS
    public int vidaBase = 4;

    public int vidaMax = 10;


    public int vidaActual;
    private CharacterStats stats;

    public event Action OnDanoRecibido; // evento para notificar dano recibido

    bool siEsperamos = false;//variable para espera de la animación de muerte
    bool siEsperaDano = false;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
        vidaBase = (int)stats.health.TotalValue;
        vidaActual = vidaBase;

        //stats.OnStatChanged += OnStatChanged;
    }
    /*void OnDestroy()
    {
        if (stats != null)
            stats.OnStatChanged -= OnStatChanged;*/
    //}
    void OnStatChanged(StatType type, float newValue)
    {
        if (type == StatType.Health)
        {
            int nuevaVidaMax = Mathf.RoundToInt(newValue);
            int delta = nuevaVidaMax - vidaBase;
            vidaBase = nuevaVidaMax;
            vidaActual += delta; // opcional: curar vida extra
            vidaActual = Mathf.Clamp(vidaActual, 0, vidaBase);
            Debug.Log("Nueva vida máxima: " + vidaBase);
        }
    }

    public void RecibeDano(int cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaBase);

        Debug.Log("Vida actual: " + vidaActual);

        OnDanoRecibido?.Invoke(); // aviso que se recibio dano

        if (vidaActual <= 0)
        {
            Muerte();
        }
        if (siEsperaDano == false)
        {
            siEsperaDano = true;
            AnimacionHerido(); //llama a un método para animar el daño
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

        Debug.Log("Nueva vida maxima: " + vidaBase + " | Vida actual: " + vidaActual);
    }

    private void Muerte()
    {
        Debug.Log("El jugador ha muerto.");
        if (siEsperamos == false) //comprueba que la animación de meurte solo se active una vez
        {
            StartCoroutine(TiempoEspera());
            siEsperamos = true;
            this.GetComponent<Animator>().SetBool("siMuere", true);
            Debug.Log("reproduciendo animación de muerte");
            this.GetComponent<Caminar>().sePuedeMover = false; //hace que el jugador ya no se pueda mover
            //Entiendo que, al morir, si queremos que vaya a la escena de derrota, debo ponerlo aquí
            StartCoroutine(LlevarADerrota());
        }
    }


    public int GetCurrentHealth() => vidaActual;
    public int GetMaxHealth() => vidaBase;



    //tiempo a esperar para que se vea la animación de muerte
    IEnumerator TiempoEspera()
    {

        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false); siEsperamos = false;
    }

    void AnimacionHerido()
    {
        if (siEsperamos == false)
        {
            this.GetComponent<Animator>().SetBool("siHerido", true);
            StartCoroutine(TiempoAnim());

        }
    }
    IEnumerator TiempoAnim()
    {
        yield return new WaitForSeconds(0.4f);
        this.GetComponent<Animator>().SetBool("siHerido", false);
        siEsperaDano = false;
    }
    
    IEnumerator LlevarADerrota()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Derrota");
    }
}
