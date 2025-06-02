using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    /*public ItemData itemData;
    private bool canAbsorb;

    void Update()
    {
        if (canAbsorb && Input.GetKeyDown(KeyCode.E))
        {
            AbsorbItem();
        }
    }

    void AbsorbItem()
    {
        CharacterStats stats = FindObjectOfType<CharacterStats>();
        if (stats != null)
        {
            stats.ApplyPermamentBoost(itemData.statType, itemData.value);
            Destroy(gameObject); // Destruir el ítem después de absorberlo
            Debug.Log($"¡{itemData.itemName} absorbido permanentemente!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canAbsorb = true;
            GameManager.Instance.ShowInteractPrompt("Presiona E para absorber " + itemData.itemName);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canAbsorb = false;
            GameManager.Instance.HideInteractPrompt();
        }
    }*/
}