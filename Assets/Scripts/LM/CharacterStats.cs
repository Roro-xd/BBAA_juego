using UnityEngine;
using System;

public class CharacterStats : MonoBehaviour
{ }
    /*public event Action<StatType, float> OnStatChanged;

    [System.Serializable]
    public class Stat
    {
        public float baseValue;
        public float modifier;
        public float TotalValue => baseValue + modifier;
    }

    [Header("Estadísticas Base")]
    public Stat health = new Stat { baseValue = 100 };
    public Stat damage = new Stat { baseValue = 20 };
    public Stat moveSpeed = new Stat { baseValue = 5 };
    public Stat attackSpeed = new Stat { baseValue = 1 };
    public Stat dodgeChance = new Stat { baseValue = 0 }; // en porcentaje, por ejemplo 20 = 20%

    [Header("Estado Actual")]
    public float currentHealth;

    void Start()
    {
        currentHealth = health.TotalValue;
        UpdateHealthUI();
    }

    public void ApplyPermamentBoost(StatType statType, float value)
    {
        switch(statType)
        {
            case StatType.Health:
                health.modifier += value;
                currentHealth = Mathf.Clamp(currentHealth + value, 0, health.TotalValue);
                break;

            case StatType.Damage:
                damage.modifier += value;
                break;

            case StatType.MoveSpeed:
                moveSpeed.modifier += value;
                break;

            case StatType.AttackSpeed:
                attackSpeed.modifier += value;
                break;

            case StatType.DodgeChance:
                dodgeChance.modifier += value;
                break;
        }
        OnStatChanged?.Invoke(statType, GetStatTotal(statType)); // Notificación de cambio
        UpdateHealthUI();
    }

    public float GetStatTotal(StatType statType)
    {
        return statType switch
        {
            StatType.Health => health.TotalValue,
            StatType.Damage => damage.TotalValue,
            StatType.MoveSpeed => moveSpeed.TotalValue,
            StatType.AttackSpeed => attackSpeed.TotalValue,
            StatType.DodgeChance => dodgeChance.TotalValue,
            _ => 0f,
        };
    }

    public void TakeDamage(float amount)
    {
        // Llamamos al DodgeManager para ver si el personaje esquiva el ataque
        if (DodgeManager.Instance.IntentarEsquivar())
        {
            Debug.Log("¡Ataque esquivado! No se recibe daño.");
            return; // No se recibe daño si se esquiva
        }

        currentHealth = Mathf.Clamp(currentHealth - amount, 0, health.TotalValue);
        UpdateHealthUI();

        if (currentHealth <= 0)
            Die();
    }

    void UpdateHealthUI()
    {
        GameManager.Instance.UpdateHealthBar(currentHealth, health.TotalValue);
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Lógica de game over
    }
}*/