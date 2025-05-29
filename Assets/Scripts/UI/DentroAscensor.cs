using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DentroAscensor : MonoBehaviour
{
    public TextMeshProUGUI textoAleatorio;
    private string[] textos = {
        "Si matar fuera ilegal, estaría en la cárcel",
        "No es más limpio el que más limpia, sino el que menos ensucia",
        "Texto aleatorio número 3",
        "No puedo más con mi vida. *Da una calada*",
        "Espero que me pongan buena nota por esto." };



    public GameObject panelN;
    private Animator animPanelN;
    public GameObject indX;
    public GameObject cuadroDialogo;

    void Start()
    {
        StartCoroutine(texto());
        animPanelN = panelN.GetComponent<Animator>();
    }


    void Update()
    {
        if (indX.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            AudioManager.Instance.PlaySFX("Botones");

            indX.SetActive(false);
            //cuadroDialogo.SetActive(false);
            //textoAleatorio.SetActive(false);
            animPanelN.SetBool("Panel_in", true);
            animPanelN.SetBool("Panel_out", false);
            StartCoroutine(aparecePanelN());
        }
    }


    void TextoRandom()
    {
        int textoRandom = Random.Range(0, textos.Length);
        textoAleatorio.text = textos[textoRandom];
    }


    IEnumerator texto()
    {
        yield return new WaitForSeconds(2);
        TextoRandom();
        indX.SetActive(true);
        cuadroDialogo.SetActive(true);
    }



    IEnumerator aparecePanelN()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level_1");
    }
}
