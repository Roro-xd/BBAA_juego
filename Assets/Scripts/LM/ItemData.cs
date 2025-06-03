/*using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Configuración Básica")]
    public string itemName;
    public GameObject itemPrefab;
    public Sprite icon;
    [TextArea] public string description;
    public int shopPrice = 50;
    public bool collected;

    [Header("Modificadores de Estadísticas")]
    public StatType statType;
    
    [Tooltip("Valor numérico del efecto permanente (+/-)")]
    public float value;

    [Header("Feedback Visual")]
    public ParticleSystem absorptionEffect;
    public AudioClip absorptionSound;

    public void ResetCollectedStatus()
    {
        collected = false;
    }
}

public enum StatType
{
    Health,
    Damage,
    Cooldown,
    MoveSpeed,
    AttackSpeed,
    ProjectileQuantity,
    DodgeChance,
    SpecialAbilityUnlock
}*/