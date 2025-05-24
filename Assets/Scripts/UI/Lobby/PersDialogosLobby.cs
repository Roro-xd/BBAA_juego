using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersDialogosLobby : MonoBehaviour
{
    //Relativo al texto
    public GameObject cuadroTexto;
    public GameObject indZ;
    public GameObject indX;
    public GameObject posXadriel;
    public GameObject posXluismi;
    public GameObject posXroro;
    public GameObject posXchurro;
    public GameObject posXnapoyori;
    public GameObject textoAdriel;
    public GameObject textoLuismi;
    public GameObject textoRoro;
    public GameObject textoChurro;
    public GameObject textoNapo;
    public GameObject textoYori;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && indX.activeSelf)
        {
            SuenaBoton();
            AparicionTexto();

            if (indX.transform.position == posXadriel.transform.position)
            {
                textoAdriel.SetActive(true);
            }
            else if (indX.transform.position == posXluismi.transform.position)
            {
                textoLuismi.SetActive(true);
            }
            else if (indX.transform.position == posXroro.transform.position)
            {
                textoRoro.SetActive(true);
            }
            else if (indX.transform.position == posXchurro.transform.position)
            {
                textoChurro.SetActive(true);
            }
            else if (indX.transform.position == posXnapoyori.transform.position)
            {
                textoYori.SetActive(true);
            }

            indX.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z) && indZ.activeSelf && textoYori.activeSelf)
        {
            textoYori.SetActive(false);
            textoNapo.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.Z) && indZ.activeSelf && textoYori.activeSelf == false)
        {
            SuenaVolver();
            cuadroTexto.SetActive(false);
            indZ.SetActive(false);
            textoAdriel.SetActive(false);
            textoLuismi.SetActive(false);
            textoRoro.SetActive(false);
            textoChurro.SetActive(false);
            textoNapo.SetActive(false);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        indX.SetActive(true);

        if (col.gameObject.name == "ZonaAdriel")
        {
            indX.transform.position = posXadriel.transform.position;
        }
        else if (col.gameObject.name == "ZonaLuismi")
        {
            indX.transform.position = posXluismi.transform.position;
        }
        else if (col.gameObject.name == "ZonaRoro")
        {
            indX.transform.position = posXroro.transform.position;
        }
        else if (col.gameObject.name == "ZonaChurro")
        {
            indX.transform.position = posXchurro.transform.position;
        }
        else if (col.gameObject.name == "ZonaNapoYori")
        {
            indX.transform.position = posXnapoyori.transform.position;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        indX.SetActive(false);
    }


    public void AparicionTexto()
    {
        cuadroTexto.SetActive(true);
        indZ.SetActive(true);
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
