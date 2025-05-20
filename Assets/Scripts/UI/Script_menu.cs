using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_menu : MonoBehaviour
{

    GameObject panelMenu;
    GameObject panelSeguro;
    GameObject panelVolumen;
    GameObject panelControles;

    void Start()
    {

        panelMenu = GameObject.Find("Panel_menu");
        panelMenu.SetActive(false);

        panelSeguro = GameObject.Find("Panel_seguro");
        panelSeguro.SetActive(false);

        panelVolumen = GameObject.Find("Panel_volumen");
        panelVolumen.SetActive(false);

        panelControles = GameObject.Find("Panel_controles");
        panelControles.SetActive(false);


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelMenu.SetActive(true);
            AudioManager.Instance.PlaySFX("Botones");
        }
    }

    public void AbrirVol()
    {
        panelVolumen.SetActive(true);
        panelMenu.SetActive(false);

    }

    public void CerrarVol()
    {
        panelVolumen.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void AbriControles()
    {
        panelControles.SetActive(true);
        panelMenu.SetActive(false);
    }

    public void CerrarControles()
    {
        panelControles.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void SalirJuego()
    {
        panelSeguro.SetActive(true);
    }

    public void ContinuarJuego()
    {
        panelMenu.SetActive(false);
    }

    public void SiQuiero()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void NoQuiero()
    {
        panelSeguro.SetActive(false);
    }
    

    public void SuenaBoton()
    {
        AudioManager.Instance.PlaySFX("Botones");
    }

    //Respecto a sonidos
    public void SuenaVolver()
    {
        AudioManager.Instance.PlaySFX("Volver");

    }
}
