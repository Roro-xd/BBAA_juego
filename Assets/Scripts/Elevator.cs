using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    [Header("UI References")]
    public GameObject levelSelectUI;
    public Button[] levelButtons;  // Debes asignar 3 botones en el Inspector
    public Button backButton;

    [Header("Configuration")]
    public string levelPrefix = "Level_";
    public Color unlockedColor = Color.green;
    public Color lockedColor = Color.red;

    private bool isPlayerNear;

    void Start()
    {
        // Configurar botones dinámicamente según cuántos tengas asignados
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelNumber = i + 1;  // Los niveles empiezan en 1
            levelButtons[i].onClick.AddListener(() => SelectLevel(levelNumber));
        }

        backButton.onClick.AddListener(CloseLevelSelect);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !levelSelectUI.activeSelf)
        {
            OpenLevelSelect();
        }
    }

    void OpenLevelSelect()
    {
        if (levelSelectUI == null)
        {
            Debug.LogError("¡No hay UI asignada para selección de niveles!");
            return;
        }

        levelSelectUI.SetActive(true);
        UpdateLevelButtons();
        Time.timeScale = 0f;
    }

    void UpdateLevelButtons()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager no encontrado en la escena!");
            return;
        }

        if (levelButtons == null || levelButtons.Length == 0)
        {
            Debug.LogError("No hay botones de nivel asignados en el Inspector!");
            return;
        }

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (levelButtons[i] == null)
            {
                Debug.LogError($"Botón del nivel {i + 1} no asignado!");
                continue;
            }

            bool isUnlocked = (i + 1) <= GameManager.Instance.maxUnlockedLevel;
            levelButtons[i].interactable = isUnlocked;

            Image buttonImage = levelButtons[i].GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = isUnlocked ? unlockedColor : lockedColor;
            }
            else
            {
                Debug.LogError($"Botón del nivel {i + 1} no tiene componente Image!");
            }
        }
    }

    public void SelectLevel(int levelNumber)
    {
        if (levelNumber < 1 || levelNumber > levelButtons.Length)
        {
            Debug.LogError($"Número de nivel inválido: {levelNumber}");
            return;
        }

        GameManager.Instance.currentLevel = levelNumber;
        CloseLevelSelect();
        SceneManager.LoadScene($"{levelPrefix}{levelNumber}");
    }

    void CloseLevelSelect()
    {
        if (levelSelectUI != null)
        {
            levelSelectUI.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Jugador en zona de ascensor");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            CloseLevelSelect();
        }
    }
}