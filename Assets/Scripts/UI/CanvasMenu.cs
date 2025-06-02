using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMenu : MonoBehaviour
{

    public static CanvasMenu Instance;


    //Control de los paneles
    public GameObject panelPartida;
    public GameObject panelMenu;
    public GameObject panelSeguro;
    public GameObject panelVolumen;
    public GameObject panelControles;

    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (scene.name == "Inicio" || scene.name == "Victoria" || scene.name == "Derrota" || scene.name == "InicioLobby")
        {
            panelPartida.gameObject.SetActive(false);
        }
        else
        {
            panelPartida.gameObject.SetActive(true);
        }
    }


    // Start is called before the first frame update    
    void Start()
    {

        panelMenu = GameObject.Find("Panel_menu");
        panelMenu.SetActive(false);

        panelSeguro = GameObject.Find("Panel_seguro");
        panelSeguro.SetActive(false);

        panelVolumen = GameObject.Find("Panel_volumen");
        panelVolumen.SetActive(false);

        panelControles = GameObject.Find("Panel_controles");
        panelControles.SetActive(false);

        panelPartida = GameObject.Find("Panel_UI_Partida");
        panelPartida.SetActive(false);

    }

    void Update()
    {
        //Activar menú con Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelMenu.activeSelf == false && panelSeguro.activeSelf == false && panelVolumen.activeSelf == false && panelControles.activeSelf == false)
            {
                panelMenu.SetActive(true);
                AudioManager.Instance.PlaySFX("Botones");
            }
        }

    }



    //INTERACCIÓNES CON LOS BOTONES
    public void AbrirVol()
    {
        panelVolumen.SetActive(true);
        panelMenu.SetActive(false);

    }

    public void CerrarVol()
    {
        panelVolumen.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void AbriControles()
    {
        panelControles.SetActive(true);
        panelMenu.SetActive(false);
    }

    public void CerrarControles()
    {
        panelControles.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void SalirJuego()
    {
        panelSeguro.SetActive(true);
    }

    public void ContinuarJuego()
    {
        Debug.Log("Continuar");
        panelMenu.SetActive(false);
        
    }

    public void SiQuiero()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void NoQuiero()
    {
        panelSeguro.SetActive(false);
    }
    

    //Respecto a sonidos
    public void SuenaBoton()
    {
        AudioManager.Instance.PlaySFX("Botones");
    }

    public void SuenaVolver()
    {
        AudioManager.Instance.PlaySFX("Volver");

    }
}
