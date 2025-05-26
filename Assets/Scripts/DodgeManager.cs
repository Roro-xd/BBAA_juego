using UnityEngine;

public class DodgeManager : MonoBehaviour
{
    public static DodgeManager Instance;

    private CharacterStats characterStats;
    private float dodgeProbability;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    public bool IntentarEsquivar()
    {
        // Obtener el valor total de esquiva desde CharacterStats
        dodgeProbability = characterStats.dodgeChance.TotalValue;

        float probabilidadAleatoria = Random.Range(0f, 100f); // Generar un número aleatorio entre 0 y 100

        if (probabilidadAleatoria <= dodgeProbability)
        {
            Debug.Log("¡Esquivaste el ataque!");
            return true; // El personaje esquiva el ataque
        }

        return false; // El personaje no esquiva el ataque
    }
}


