using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Relaciones : MonoBehaviour
{
    //NIVELES INICIALES DE CADA PERSONAJE
    public int nivelChurro = 0;
    public int nivelNapo = 0;
    public int nivelYori = 0;

    //Enlace con su texto en el Canvas
    public TextMeshProUGUI textoNivelCh;
    public TextMeshProUGUI textoNivelN;
    public TextMeshProUGUI textoNivelY;


    //Cambio de color según niveles
    public Color colorNegativo = new Color(0.62f, 0.14f, 0.043f);
    public Color colorCero = Color.white;
    public Color colorPositivo = new Color(0.0666f, 0.443f, 0.325f);



    //SOLO CHURRO Y NAPO PUEDEN VARIAR SU NIVEL EN LA DEMO --- funciones correspondientes
    public void CambioNivelChurro(int cambio)
    {
        nivelChurro += cambio;
    }

    public void CambioNivelNapo(int cambio)
    {
        nivelNapo += cambio;
    }



    void Update()
    {
        //CAMBIO CONSTANTE DE LOS NIVELES + CAMBIAR RESPECTIVOS TEXTOS
        textoNivelCh.GetComponent<TextMeshProUGUI>().text = nivelChurro.ToString() + " punto(s)";
        textoNivelN.GetComponent<TextMeshProUGUI>().text = nivelNapo.ToString() + " punto(s)";
        textoNivelY.GetComponent<TextMeshProUGUI>().text = nivelYori.ToString() + " punto(s)";

        ActualizarColorChurro();
        ActualizarColorNapo();
    }


    //Actualización de color según nivel --- CHURRO
    public void ActualizarColorChurro()
    {
        if (nivelChurro < 0)
        {
            textoNivelCh.color = colorNegativo;
        }
        else if (nivelChurro == 0)
        {
            textoNivelCh.color = colorCero;
        }
        else
        {
            textoNivelCh.color = colorPositivo;
        }
    }


    //Actualización de color según nivel --- NAPO
    public void ActualizarColorNapo()
    {
        if (nivelNapo < 0)
        {
            textoNivelN.color = colorNegativo;
        }
        else if (nivelNapo == 0)
        {
            textoNivelN.color = colorCero;
        }
        else
        {
            textoNivelN.color = colorPositivo;
        }
    }
}
