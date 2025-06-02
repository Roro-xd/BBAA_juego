using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Relaciones : MonoBehaviour
{

    //Enlace con su texto en el Canvas
    public GameObject textoNivelCh;
    public GameObject textoNivelN;
    public GameObject textoNivelY;


    //Cambio de color según niveles
    private Color colorNegativo = new Color(0.62f, 0.14f, 0.043f);
    private Color colorCero = Color.white;
    private Color colorPositivo = new Color(0.0666f, 0.443f, 0.325f);



    void Start()
    {
        if (Vida.Instance != null)
        {
            Vida.Instance.nivelChurro = 0;
            Vida.Instance.nivelNapo = 0;
            Vida.Instance.nivelYori = 0;
        }
    }





    //SOLO CHURRO Y NAPO PUEDEN VARIAR SU NIVEL EN LA DEMO --- funciones correspondientes
    public void CambioNivelChurro(int cambio)
    {
        Vida.Instance.nivelChurro += cambio;
    }

    public void CambioNivelNapo(int cambio)
    {
        Vida.Instance.nivelNapo += cambio;
    }



    void Update()
    {
        //CAMBIO CONSTANTE DE LOS NIVELES + CAMBIAR RESPECTIVOS TEXTOS
        textoNivelCh.GetComponent<TextMeshProUGUI>().text = Vida.Instance.nivelChurro.ToString() + " punto(s)";
        textoNivelN.GetComponent<TextMeshProUGUI>().text = Vida.Instance.nivelNapo.ToString() + " punto(s)";
        textoNivelY.GetComponent<TextMeshProUGUI>().text = Vida.Instance.nivelYori.ToString() + " punto(s)";

        ActualizarColorChurro();
        ActualizarColorNapo();
    }


    //Actualización de color según nivel --- CHURRO
    public void ActualizarColorChurro()
    {
        if (Vida.Instance.nivelChurro < 0)
        {
            textoNivelCh.GetComponent<TextMeshProUGUI>().color = colorNegativo;
        }
        else if (Vida.Instance.nivelChurro == 0)
        {
            textoNivelCh.GetComponent<TextMeshProUGUI>().color = colorCero;
        }
        else
        {
            textoNivelCh.GetComponent<TextMeshProUGUI>().color = colorPositivo;
        }
    }


    //Actualización de color según nivel --- NAPO
    public void ActualizarColorNapo()
    {
        if (Vida.Instance.nivelNapo < 0)
        {
            textoNivelN.GetComponent<TextMeshProUGUI>().color = colorNegativo;
        }
        else if (Vida.Instance.nivelNapo == 0)
        {
            textoNivelN.GetComponent<TextMeshProUGUI>().color = colorCero;
        }
        else
        {
            textoNivelN.GetComponent<TextMeshProUGUI>().color = colorPositivo;
        }
    }
}
