using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoriLobby : MonoBehaviour
{
    private Animator yoriAnim;
    public GameObject yori;

    public GameObject[] textosYori;
    public int lineaYori = 1;


    public GameObject xYori;
    public GameObject baseTexto;
    public GameObject textoYori;
    public GameObject dialogoYori;


    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;

    private bool puedoConversar;



    void Start()
    {
        yoriAnim = yori.GetComponent<Animator>();
        yoriAnim.SetBool("YoriIdle", true);
        yoriAnim.SetBool("YoriParado", false);

        textoYori.SetActive(false);
        xYori.SetActive(false);
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


        if (xYori.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar)
        {
            //AvanceTextoYori();
            baseTexto.SetActive(true);
            textoYori.SetActive(true);
            dialogoYori.SetActive(true);

            xYori.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaYori == 0 && textoYori.activeSelf)
        {
            AvanceTextoYori();
            dialogoYori.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaYori == 1 && textoYori.activeSelf)
        {
            AvanceTextoYori();
            baseTexto.SetActive(false);
            textoYori.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
        }
    }



    public void AvanceTextoYori()
    {
        textosYori[lineaYori].SetActive(false);
        lineaYori = (lineaYori + 1) % textosYori.Length;
        textosYori[lineaYori].SetActive(true);
    }
    


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xYori.SetActive(true);
        }
    }
    

    void OnTriggerExit2D(Collider2D col)
    {
        xYori.SetActive(false);
    }
}
