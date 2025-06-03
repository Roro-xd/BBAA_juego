using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoss_Script : MonoBehaviour
{
    //Conversación entre Churro y Buñuelo
    public GameObject[] textos;
    public int numTexto = 0;

    //Otros elementos relacionados con la conver
    public GameObject zRegresa;
    public GameObject xAvanza;
    public GameObject cuadrotexto;

    //Panel introductorio del boss
    public GameObject panelIndBoss;
    public GameObject textosConj;

    //Referencia al menú para que se pueda pausar la conver mientras se está en pausa
    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;

    //Vida visual de Churro
    public GameObject sliderChurro;

    void Start()
    {
        //Aparicion de la conver con un poco de retraso
        //StartCoroutine(AparicionTexto());
    }

    void Update()
    {
        //No poder ir al mensaje anterior (el último realmente) si es el primero
        if (numTexto == 0)
        {
            zRegresa.SetActive(false);
        }
        //No poder ir al mensaje posterior (otra vez el 1º) si es el último
        else if (numTexto == 3)
        {
            zRegresa.SetActive(false);
            xAvanza.SetActive(false);
        }
        //Activar ambas posibilidades si no es ninguno de los dos anteriores mencionados
        else
        {
            zRegresa.SetActive(true);
            xAvanza.SetActive(true);
        }



        //SI NO SE ESTÁ EN PAUSA (sé que se podría hacer una bool para identificar esto sin tener que ponerlo todo el rato)
        //+
        //PRESIONAR TECLA X (avanzar)
        if (Input.GetKeyDown(KeyCode.X) && xAvanza.activeSelf && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            if (numTexto != 3)
            {
                AvanceTexto();
            }

            //En caso de ser el último texto
            if (numTexto == 3)
            {
                cuadrotexto.SetActive(false);
                panelIndBoss.SetActive(true);
                sliderChurro.SetActive(true);
                //Para que no haya opción a que vuelvan a aparecer por algún conflicto de uso de la misma tecla
                Destroy(textosConj);
            }
        }


        //Retroceder conver (Z)
        if (Input.GetKeyDown(KeyCode.Z) && zRegresa.activeSelf  && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            RetrocesoTexto();


        }
        //Que de error si se intenta retroceder en el primer mensaje
        else if (Input.GetKeyDown(KeyCode.Z) && numTexto == 0 && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            AudioManager.Instance.PlaySFX("Error");
        }



    }




    public void AvanceTexto()
    {
        AudioManager.Instance.PlaySFX("Botones");
        textos[numTexto].SetActive(false);
        numTexto = (numTexto + 1) % textos.Length;
        textos[numTexto].SetActive(true);
    }

    public void RetrocesoTexto()
    {
        AudioManager.Instance.PlaySFX("Volver");
        textos[numTexto].SetActive(false);
        numTexto--;
        if (numTexto < 0)
        {
            numTexto += textos.Length;
        }

        textos[numTexto].SetActive(true);
    }


    IEnumerator AparicionTexto()
    {
        yield return new WaitForSeconds(0.5f);
        xAvanza.SetActive(true);
        cuadrotexto.SetActive(true);
        textos[0].SetActive(true);

    }

}
