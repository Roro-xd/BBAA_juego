using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Script_guion_inicio : MonoBehaviour
{

    GameObject indicarZ;
    

    public GameObject[] conversaciones;
    public int selectedDialogue = 0;



    void Start()
    {
        indicarZ = GameObject.Find("BotonPrevDialogo");
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (selectedDialogue == 23) 
            {
                SceneManager.LoadScene("Inicio"); //CAMBIAR A PARTIDA CUANDO ESTÉ PREPARADO
            }
            else
            {
                AudioManager.Instance.PlaySFX("Botones");
                conversaciones[selectedDialogue].SetActive(false);
                selectedDialogue = (selectedDialogue + 1) % conversaciones.Length;
                conversaciones[selectedDialogue].SetActive(true);
            }
        }


        if (Input.GetKeyDown(KeyCode.Z) && selectedDialogue != 0)
        {
            AudioManager.Instance.PlaySFX("Volver");
            conversaciones[selectedDialogue].SetActive(false);
            selectedDialogue--;
            if (selectedDialogue < 0)
            {
                selectedDialogue += conversaciones.Length;
            }

            conversaciones[selectedDialogue].SetActive(true);
        }

        if (selectedDialogue == 0)
        {
            indicarZ.SetActive(false);
        }
        else
        { 
            indicarZ.SetActive(true);
        }
    }

}
