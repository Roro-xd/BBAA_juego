using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Relaciones : MonoBehaviour
{
    public int nivelChurro = 0;
    public int nivelNapo = 0;
    public int nivelYori = 0;

    public TextMeshProUGUI textoNivelCh;
    public TextMeshProUGUI textoNivelN;
    public TextMeshProUGUI textoNivelY;


    public Color colorNegativo = new Color(0.62f, 0.14f, 0.043f);
    public Color colorCero = Color.white;
    public Color colorPositivo = new Color(0.0666f, 0.443f, 0.325f);



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
        textoNivelCh.GetComponent<TextMeshProUGUI>().text = nivelChurro.ToString();
        textoNivelN.GetComponent<TextMeshProUGUI>().text = nivelNapo.ToString();
        textoNivelY.GetComponent<TextMeshProUGUI>().text = nivelYori.ToString();

        ActualizarColorChurro();
        ActualizarColorNapo();
    }


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
