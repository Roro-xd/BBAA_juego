using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Script_victoria : MonoBehaviour
{

    private GameObject churro;
    private Animator animChurro;

    private GameObject napo;
    private Animator animNapo;

    private GameObject yori;
    private Animator animYori;


    void Start()
    {
        churro = GameObject.Find("Churro");
        animChurro = churro.GetComponent<Animator>();

        napo = GameObject.Find("Napo");
        animNapo = napo.GetComponent<Animator>();

        yori = GameObject.Find("Yorique");
        animYori = yori.GetComponent<Animator>();



        animChurro.SetBool("ChurroCaminaVIC", true);
        animChurro.SetBool("ChurroParado", false);
        StartCoroutine("ChurroAIdle");


        //PONER DONDE TOQUE (AL PRESIONAR TECLA)
        //animNapo.SetBool("NapoVICCamina", true);
        //animNapo.SetBool("NapoParada", false);
        //animYori.SetBool("YoriParado", false);
        //animYori.SetBool("Yor_VIC_Caminado", true);


    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator ChurroAIdle()
    {
        yield return new WaitForSeconds(4);
        animChurro.SetBool("ChurroCaminaVIC", false);
        animChurro.SetBool("ChurroVICIdle", true);
    }

}
