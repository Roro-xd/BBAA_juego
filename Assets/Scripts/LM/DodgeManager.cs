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
        // Asegúrate de que el componente CharacterStats esté correctamente asignado
        characterStats = GetComponent<CharacterStats>();

        // Verificar si characterStats es null
        if (characterStats == null)
        {
            Debug.LogError("CharacterStats no encontrado en el personaje. Asegúrate de que el componente CharacterStats esté agregado.");
        }
    }

    public bool IntentarEsquivar()
    {
        // Verificar que characterStats no es null antes de acceder a dodgeChance
        if (characterStats == null)
        {
            return false; // Si no se ha encontrado CharacterStats, no podemos esquivar
        }

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



