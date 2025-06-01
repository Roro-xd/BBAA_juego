using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaJefe : MonoBehaviour
{
    public int vidaMaxima = 60;
    public int vidaActual;
    public bool estaMuerto = false;
    private bool segundaFaseActivada = false;


    //Para su barra de vida 
    public Slider vidaChurroSlider;

    public UnityEvent eventoSegundaFase;


    public bool animHerido = false;//para comprobar que la animación de herido no se esté ejecutando ya

    void Start()
    {
        vidaActual = vidaMaxima;
        CambioVidaChurro();
    }

    public void RecibirDano(int cantidad)
    {
        if (estaMuerto) return;

        vidaActual -= cantidad;
        vidaActual = Mathf.Max(vidaActual, 0);
        CambioVidaChurro();

        Debug.Log($"Jefe recibió {cantidad} de daño. Vida actual: {vidaActual}");

        // Activa la segunda fase al 50%
        if (!segundaFaseActivada && vidaActual <= vidaMaxima / 2)
        {
            segundaFaseActivada = true;
            Debug.Log("¡Segunda fase activada!");
            eventoSegundaFase.Invoke(); // Dispara la segunda fase
        }

        //Activa la animación de herido
        if (animHerido == false)
        {
            animHerido = true;
            AudioManager.Instance.PlaySFX("DanoChurro");
            this.GetComponent<Animator>().SetBool("siHerido", true);
            StartCoroutine(TiempoAnimacion());
        }

        if (vidaActual <= 0)
        {
            Morir();
            SceneManager.LoadScene("Victoria");
        }

    }


    public void Morir()
    {
        AudioManager.Instance.PlaySFX("MuerteChurro");
        estaMuerto = true;
        Debug.Log("El jefe ha muerto.");
        gameObject.SetActive(false);
    }

    IEnumerator TiempoAnimacion() //termina la animación de herido
    {
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<Animator>().SetBool("siHerido", false);
        animHerido = false;
    }


    /*IEnumerator TiempoMuerteChurro() //termina la animación de herido
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Victoria");
    }*/

    private void CambioVidaChurro()
    {
        if (vidaChurroSlider != null)
        {
            vidaChurroSlider.value = (float)vidaActual / vidaMaxima;
        }
    }


}