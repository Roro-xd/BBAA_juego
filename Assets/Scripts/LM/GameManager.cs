/*using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Progreso del Jugador")]
    public int currentCoins;
    public int currentLevel = 1;
    public int maxUnlockedLevel = 1;
    public int playerStrength;
    public int playerSpeed;
    public int selectedCharacterIndex; // 0 o 1

    [Header("UI de Interacción")]
    public Text interactPromptText;

    [Header("UI de Vida")]
    public Image healthBarFill; // Asigna aquí el fill de tu barra de vida

    [Header("Coin System")]
    public TextMeshProUGUI coinsText;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UpdateCoinUI();
    }

    public void UpdateCoinUI()
    {
        coinsText.text = currentCoins.ToString();
    }

    // Para resetear en nueva partida
    public void ResetGame()
    {
        currentCoins = 0;
        UpdateCoinUI();
    }

    public void UnlockNextLevel()
    {
        if (currentLevel >= maxUnlockedLevel)
        {
            maxUnlockedLevel = Mathf.Clamp(currentLevel + 1, 1, 3); // 3 niveles máximo
        }
    }

    public void ShowInteractPrompt(string message)
    {
        if (interactPromptText != null)
        {
            interactPromptText.text = message;
            interactPromptText.gameObject.SetActive(true);
        }
    }

    public void HideInteractPrompt()
    {
        if (interactPromptText != null)
        {
            interactPromptText.gameObject.SetActive(false);
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }
}
*/