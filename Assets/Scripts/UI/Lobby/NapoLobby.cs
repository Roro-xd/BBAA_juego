using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapoLobby : MonoBehaviour
{
    //Animación Idle
    private Animator napoAnim;
    public GameObject napo;


    //Líneas de conversación de Napo
    public GameObject[] textosNapo;
    public int lineaNapo = 0;


    //Conver visual (cuadro, texto y demás)
    public GameObject xNapo;
    public GameObject baseTexto;
    public GameObject textoNapo;
    public GameObject textoNapoFinal;
    public GameObject textoNapoNivel;
    public GameObject dialogoNapo;


    //Mencionar paneles del menú para que no se pueda alterar la conver si se está en pausa
    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;


    //Resumir en una bool si el menú está abierto o no
    private bool puedoConversar;


    //Hacer referencia al script de Relaciones para poder mencionar el nivel de Churro
    public GameObject panelElecciones;
    public GameObject elecNapo;
    public GameObject bun;
    private JugadorMonedas dinero;
    private Relaciones relaciones;



    void Start()
    {
        //Establzco animacion Idle
        napoAnim = napo.GetComponent<Animator>();
        napoAnim.SetBool("NapoIdle", true);
        napoAnim.SetBool("NapoParada", false);

        textoNapo.SetActive(false);
        xNapo.SetActive(false);

        relaciones = bun.GetComponent<Relaciones>();

        //Como existe la posibilidad de que te de dinero según su nivel, lo relaciono con JugadorMonedas
        dinero = bun.GetComponent<JugadorMonedas>();
    }


    void Update()
    {

        //Comprobación de la bool del menú
        if (panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            puedoConversar = true;
        }
        else
        {
            puedoConversar = false;
        }


        //Si puedo iniciar la conver y la inicio (pulsar X) --- primera conver
        if (xNapo.activeSelf && Input.GetKeyDown(KeyCode.X) && puedoConversar && textoNapo != null)
        {
            baseTexto.SetActive(true);
            textoNapo.SetActive(true);
            dialogoNapo.SetActive(true);

            xNapo.SetActive(false);
            AudioManager.Instance.PlaySFX("Botones");
        }
        //Aparición de elecciones
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaNapo == 0 && textoNapo.activeSelf)
        {
            panelElecciones.SetActive(true);
            elecNapo.SetActive(true);

            AudioManager.Instance.PlaySFX("Botones");
        }
        //Cerrar y destruir primera conver al acabarla
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && lineaNapo == 1 && textoNapo.activeSelf)
        {
            textoNapo.SetActive(false);
            AudioManager.Instance.PlaySFX("Volver");
            lineaNapo = 2;
            dialogoNapo.SetActive(false);
            baseTexto.SetActive(false);
            Destroy(textoNapo);
        }


        //Inicio segunda conver
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
            //Continuar segunda conver
            if (textoNapoNivel != null)
            {
                textoNapoFinal.SetActive(false);
                textoNapoNivel.SetActive(true);
                AudioManager.Instance.PlaySFX("Botones");
            }
            //Cerrar segunda conver
            else
            {
                textoNapoFinal.SetActive(false);
                AudioManager.Instance.PlaySFX("Volver");
                dialogoNapo.SetActive(false);
                baseTexto.SetActive(false);
            }
        }
        //Continuacion de la conver --- SOLO SI SE TIENE EL NIVEL SUFICIENTE
        else if (Input.GetKeyDown(KeyCode.X) && puedoConversar && textoNapoNivel.activeSelf)
        {
            textoNapoNivel.SetActive(false);
            AudioManager.Instance.PlaySFX("dineroRecoger");
            dinero.CambioMonedas(15);
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


    //La X sobre el personaje me indica que puedo iniciar la conver
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            xNapo.SetActive(true);
        }
    }


    //Si salgo de su rango, no puedo conversar
    void OnTriggerExit2D(Collider2D col)
    {
        xNapo.SetActive(false);
    }


    //PRIMERA ELECCIÓN (relacionado con botón correspondiente) --- aumento nivel en 2 + 15 dinero 
    public void Eleccion1Napo()
    {
        panelElecciones.SetActive(false);
        elecNapo.SetActive(false);

        AvanceTextoNapo();
        AudioManager.Instance.PlaySFX("itemRecoger");
        relaciones.CambioNivelNapo(2);
    }


    //SEGUNDA ELECCIÓN (relacionado con botón correspondiente) --- mantenimiento nivel 0
    public void Eleccion2Napo()
    {
        panelElecciones.SetActive(false);
        elecNapo.SetActive(false);

        AvanceTextoNapo();
        AudioManager.Instance.PlaySFX("Botones");
        relaciones.CambioNivelNapo(0); //NO HARÍA FALTA PONERLO, PERO ES MÁS VISUAL Y FÁCIL DE DIFERENCIAR ENTRE TANTO TEXTO
        Destroy(textoNapoNivel);
    }
}
