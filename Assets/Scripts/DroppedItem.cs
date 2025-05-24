using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public ItemData itemData;
    private bool canAbsorb;

    void Update()
    {
        if(canAbsorb && Input.GetKeyDown(KeyCode.E))
        {
            AbsorbItem();
        }
    }

    void AbsorbItem()
    {
        CharacterStats stats = FindObjectOfType<CharacterStats>();
        stats.ApplyPermamentBoost(itemData.statType, itemData.value);
        
        Destroy(gameObject);
        Debug.Log($"¡{itemData.itemName} absorbido permanentemente!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) canAbsorb = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")) canAbsorb = false;
    }
}