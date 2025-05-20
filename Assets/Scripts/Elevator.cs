using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject levelSelectUI;         // Panel padre con toda la interfaz
    public Button[] levelButtons;            // Botones de niveles (0 = Nivel 1, 1 = Nivel 2, etc)
    public Button backButton;                // Botón para cerrar el menú

    [Header("Configuración")]
    public string levelPrefix = "Level_";    // Prefijo de nombre de escenas

    private bool isPlayerNear;

    void Start()
    {
        // Configurar listeners de botones
        backButton.onClick.AddListener(CloseLevelSelect);
        
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1; // Los niveles empiezan en 1
            levelButtons[i].onClick.AddListener(() => SelectLevel(levelIndex));
        }
    }

    void Update()
    {
        // Solo detectar input si el jugador está cerca
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !levelSelectUI.activeSelf)
        {
            OpenLevelSelect();
        }
    }

    // Actualiza el estado de los botones (niveles bloqueados/desbloqueados)
    void UpdateLevelButtons()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            bool isUnlocked = (i + 1) <= GameManager.Instance.maxUnlockedLevel;
            levelButtons[i].interactable = isUnlocked;

            // Opcional: Cambiar color para feedback visual
            levelButtons[i].image.color = isUnlocked ? Color.green : Color.red;
        }
    }

    void OpenLevelSelect()
    {
        levelSelectUI.SetActive(true);
        UpdateLevelButtons();
        Time.timeScale = 0f; // Pausar el juego
    }

    void CloseLevelSelect()
    {
        levelSelectUI.SetActive(false);
        Time.timeScale = 1f; // Reanudar juego
    }

    void SelectLevel(int levelNumber)
    {
        GameManager.Instance.currentLevel = levelNumber;
        CloseLevelSelect();
        SceneManager.LoadScene(levelPrefix + levelNumber);
    }

    // Detección del jugador
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            // Opcional: Mostrar texto "Presiona E"
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            CloseLevelSelect(); // Cerrar menú si el jugador se aleja
        }
    }
}