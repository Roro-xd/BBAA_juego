using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_menu : MonoBehaviour
{

    //Control de los paneles
    GameObject panelMenu;
    GameObject panelSeguro;
    GameObject panelVolumen;
    GameObject panelControles;

    //GameObject panelGuion;

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

        //panelGuion = GameObject.Find("Panel_guion");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
            {
                panelMenu.SetActive(true);
                AudioManager.Instance.PlaySFX("Botones");
            }
            else if (panelMenu.activeSelf == true && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
            {
                panelMenu.SetActive(false);
                AudioManager.Instance.PlaySFX("Volver");
            }
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
        Debug.Log("Continuar");
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
    

    //Respecto a sonidos
    public void SuenaBoton()
    {
        AudioManager.Instance.PlaySFX("Botones");
    }

    public void SuenaVolver()
    {
        AudioManager.Instance.PlaySFX("Volver");

    }
}
