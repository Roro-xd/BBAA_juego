using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Script_derrota : MonoBehaviour
{
    //Referenciar al panel negro
    public GameObject panelNegro;
    private Animator animPanelNegro;

    //Referenciar los botones que salen al final
    public GameObject botonReintentar;
    public GameObject botonSalir;

    //Referenciar el cuadre de fondo del texto
    public GameObject cuadroTexto;

    //Referenciar los botones indicadores de interaccion dialogo
    public GameObject zRegresa;
    public GameObject xAvanza;

    //Crear y ordenar las lineas del monologo
    public GameObject[] monologo;
    public int lineaMonologo = 0;

    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;



    void Start()
    {
        //Que encuentre el Animator del panel negro
        animPanelNegro = panelNegro.GetComponent<Animator>();
        
        //El texto aparece una vez que el panel negro no está y se ve toda la escena
        StartCoroutine("aparicionTexto");
        
    }

    void Update()
    {
        //No te permite regresar el texto nada más empieza
        if (lineaMonologo == 0 )
        {
            zRegresa.SetActive(false);
            xAvanza.SetActive(true);
        }
        else
        { 
            zRegresa.SetActive(true);
            xAvanza.SetActive(true);
        }


        //Al presionar la tecla indicada(X)
        if (Input.GetKeyDown(KeyCode.X) && xAvanza.activeSelf && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            //Si no es la ultima linea, el texto avanza
            if (lineaMonologo != 2)
            {
                AvanceMonologo();
                AudioManager.Instance.PlaySFX("Botones");
            }
            //Si es la ultima linea, reaparece el panel negro, se desactiva el texto y al tiempo aparecen los botones finales
            else
            {
                animPanelNegro.SetBool("Panel_in", true);
                cuadroTexto.SetActive(false);
                monologo[lineaMonologo].SetActive(false);
                StartCoroutine("aparicionBotones");
            }
        }


        //Al presionar la tecla indicada(Z)
        if (Input.GetKeyDown(KeyCode.Z) && zRegresa.activeSelf && panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
        {
            //Retroce una linea del monologo
            RetrocesoMonologo();
            AudioManager.Instance.PlaySFX("Volver");

        }
        //Da error si se intenta retroceder durante el monologo y la tecla no se indica
        else if (Input.GetKeyDown(KeyCode.Z) && zRegresa.activeSelf == false && cuadroTexto.activeSelf)
        {
            if (panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false) { 
                AudioManager.Instance.PlaySFX("Error");
            }
            
        }

    }



    public void AvanceMonologo()
    {
        monologo[lineaMonologo].SetActive(false);
        lineaMonologo = (lineaMonologo + 1) % monologo.Length;
        monologo[lineaMonologo].SetActive(true);
    }


    public void RetrocesoMonologo()
    { 
        monologo[lineaMonologo].SetActive(false);
        lineaMonologo--;
            if (lineaMonologo < 0)
            {
                lineaMonologo += monologo.Length;
            }

            monologo[lineaMonologo].SetActive(true);
    }
    
    
    //Tiempo de espera para que aparezcan los bonotes finales
    IEnumerator aparicionBotones()
    {
        yield return new WaitForSeconds(2);
        botonReintentar.SetActive(true);
        botonSalir.SetActive(true);
    }


    //Tiempo de espera para que aparezca el texto al iniciar la escena
    IEnumerator aparicionTexto()
    {
        yield return new WaitForSeconds(1);
        cuadroTexto.SetActive(true);
        monologo[0].SetActive(true);
    }


    //Funciones para los botones del final
    public void SalirJuego()
    {
        Application.Quit();
    }

    public void Reintentar()
    {
        SceneManager.LoadScene("Inicio");
    }
    
    
}
