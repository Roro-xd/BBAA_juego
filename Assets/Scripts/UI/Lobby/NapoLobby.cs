using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapoLobby : MonoBehaviour
{
    private Animator napoAnim;
    public GameObject napo;

    public GameObject[] textosNapo;
    public int lineaNapo = 0;


    public GameObject xNapo;
    public GameObject baseTexto;
    public GameObject textoNapo;
    public GameObject textoNapoFinal;
    public GameObject textoNapoNivel;
    public GameObject dialogoNapo;


    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;

    private bool puedoConversar;


    //hacer referencia al script de Relaciones para poder mencionar el nivel de Churro
    public GameObject panelElecciones;
    public GameObject elecNapo;
    public GameObject bun;
    private JugadorMonedas dinero;
    private Relaciones relaciones;

    void Start()
    {
        napoAnim = napo.GetComponent<Animator>();
        napoAnim.SetBool("NapoIdle", true);
        napoAnim.SetBool("NapoParada", false);

        textoNapo.SetActive(false);
        xNapo.SetActive(false);

        relaciones = bun.GetComponent<Relaciones>();

        dinero = bun.GetComponent<JugadorMonedas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            puedoConversar = true;
        }
        else
        {
            puedoConversar = false;
        }


        if (xNapo.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar && textoNapo != null)
        {
            baseTexto.SetActive(true);
            textoNapo.SetActive(true);
            dialogoNapo.SetActive(true);

            xNapo.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaNapo == 0 && textoNapo.activeSelf)
        {
            panelElecciones.SetActive(true);
            elecNapo.SetActive(true);

            AudioManager.Instance.PlaySFX("Botones");
        }
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaNapo == 1 && textoNapo.activeSelf)
        {
            textoNapo.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
            lineaNapo = 2;
            dialogoNapo.SetActive(false);
            baseTexto.SetActive(false);
            Destroy(textoNapo);
        }


        if (xNapo.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar && textoNapo == null)
        {
            textoNapoFinal.SetActive(true);
            AudioManager.Instance.PlaySFX("Botones");
            dialogoNapo.SetActive(true);
            baseTexto.SetActive(true);
            xNapo.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && textoNapoFinal.activeSelf)
        {
            if (textoNapoNivel != null)
            {
                textoNapoFinal.SetActive(false);
                textoNapoNivel.SetActive(true);
                AudioManager.Instance.PlaySFX("Botones");
            }
            else
            {
                textoNapoFinal.SetActive(false);
                AudioManager.Instance.PlaySFX("Volver");
                dialogoNapo.SetActive(false);
                baseTexto.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && textoNapoNivel.activeSelf)
        {
            textoNapoNivel.SetActive(false);
            AudioManager.Instance.PlaySFX("dineroRecoger");
            dinero.CambioMonedas(5);
            dialogoNapo.SetActive(false);
            baseTexto.SetActive(false);
            Destroy(textoNapoNivel);
        }
    }


    public void AvanceTextoNapo()
    {
        textosNapo[lineaNapo].SetActive(false);
        lineaNapo = (lineaNapo + 1) % textosNapo.Length;
        textosNapo[lineaNapo].SetActive(true);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xNapo.SetActive(true);
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        xNapo.SetActive(false);
    }

    public void Eleccion1Napo()
    {
        panelElecciones.SetActive(false);
        elecNapo.SetActive(false);

        AvanceTextoNapo();
        AudioManager.Instance.PlaySFX("itemRecoger");
        relaciones.CambioNivelNapo(2);
    }

    public void Eleccion2Napo()
    {
        panelElecciones.SetActive(false);
        elecNapo.SetActive(false);

        AvanceTextoNapo();
        AudioManager.Instance.PlaySFX("Botones");
        relaciones.CambioNivelNapo(0);
        Destroy(textoNapoNivel);
    }
}
