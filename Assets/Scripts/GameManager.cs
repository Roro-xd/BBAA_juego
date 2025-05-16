using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentCoins;
    public int currentLevel = 1;
    public int maxUnlockedLevel = 1;
    public int playerStrength;
    public int playerSpeed;
    public int selectedCharacterIndex; // 0 o 1

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
}