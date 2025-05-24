// CharacterData.cs
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Estadísticas Base")]
    public float baseHealth = 100f;
    public float baseDamage = 20f;
    public float abilityCooldown = 5f;
    public float moveSpeed = 5f;
    public float attackSpeed = 1f;
    public int projectileQuantity = 1;
    public float dodgeChance = 0.1f; // 10% de probabilidad

    [Header("Modificadores de Items")]
    public float healthModifier;
    public float damageModifier;
    public float cooldownModifier;
    public float speedModifier;
    public float attackSpeedModifier;
    public int projectileModifier;
    public float dodgeModifier;

    // Propiedades para obtener valores finales
    public float TotalHealth => baseHealth + healthModifier;
    public float TotalDamage => baseDamage + damageModifier;
    public float TotalCooldown => Mathf.Max(0.5f, abilityCooldown - cooldownModifier);
    public float TotalMoveSpeed => moveSpeed + speedModifier;
    public float TotalAttackSpeed => attackSpeed + attackSpeedModifier;
    public int TotalProjectiles => projectileQuantity + projectileModifier;
    public float TotalDodge => Mathf.Clamp(dodgeChance + dodgeModifier, 0f, 0.8f); // Máximo 80%
}