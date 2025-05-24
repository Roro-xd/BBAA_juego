using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VendingMachine : MonoBehaviour
{
    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public GameObject itemPrefab;
        public int price;
        public StatType statType;
        public float value;
        [HideInInspector] public bool collected;
    }

    [Header("Configuración")]
    public List<ShopItem> allItems = new List<ShopItem>();
    public int machineCost = 50;
    public Transform itemSpawnPoint;
    
    [Header("Referencias")]
    public Text coinsText;
    private bool playerInRange;
    private GameObject currentDroppedItem;
    private CharacterStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<CharacterStats>();
        UpdateUI();
    }

    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if(currentDroppedItem == null)
            {
                TryPurchase();
            }
            else
            {
                Debug.Log("¡Ya hay un item esperando ser absorbido!");
            }
        }
    }

    void TryPurchase()
    {
        if(GameManager.Instance.currentCoins >= machineCost)
        {
            GameManager.Instance.currentCoins -= machineCost;
            DispenseRandomItem();
            UpdateUI();
        }
    }

    void DispenseRandomItem()
    {
        List<ShopItem> availableItems = allItems.FindAll(item => !item.collected);
        
        if(availableItems.Count > 0)
        {
            int randomIndex = Random.Range(0, availableItems.Count);
            ShopItem selectedItem = availableItems[randomIndex];
            
            currentDroppedItem = Instantiate(
                selectedItem.itemPrefab,
                itemSpawnPoint.position,
                Quaternion.identity
            );
            
            // Configurar componente del item
            DroppedItem itemComponent = currentDroppedItem.AddComponent<DroppedItem>();
            itemComponent.Initialize(selectedItem);
            
            selectedItem.collected = true;
        }
        else
        {
            Debug.Log("¡No quedan mejoras disponibles!");
        }
    }

    void UpdateUI()
    {
        coinsText.text = GameManager.Instance.currentCoins.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
            GameManager.Instance.ShowInteractPrompt("Presiona E para comprar (" + machineCost + " monedas)");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
            GameManager.Instance.HideInteractPrompt();
        }
    }

    public class DroppedItem : MonoBehaviour
    {
        private ShopItem itemData;
        private bool canAbsorb;

        public void Initialize(ShopItem data)
        {
            itemData = data;
            gameObject.name = data.itemName + "_Pickup";
        }

        void Update()
        {
            if(canAbsorb && Input.GetKeyDown(KeyCode.E))
            {
                AbsorbItem();
            }
        }

        void AbsorbItem()
        {
            // Aplicar mejoras permanentes
            CharacterStats stats = FindObjectOfType<CharacterStats>();
            
            switch(itemData.statType)
            {
                case StatType.Health:
                    stats.ApplyPermamentBoost(StatType.Health, itemData.value);
                    break;
                case StatType.Damage:
                    stats.ApplyPermamentBoost(StatType.Damage, itemData.value);
                    break;
                case StatType.MoveSpeed:
                    stats.ApplyPermamentBoost(StatType.MoveSpeed, itemData.value);
                    break;
                case StatType.AttackSpeed:
                    stats.ApplyPermamentBoost(StatType.AttackSpeed, itemData.value);
                    break;
                case StatType.ProjectileQuantity:
                    stats.ApplyPermamentBoost(StatType.ProjectileQuantity, itemData.value);
                    break;
                case StatType.DodgeChance:
                    stats.ApplyPermamentBoost(StatType.DodgeChance, itemData.value);
                    break;
            }

            Destroy(gameObject);
            Debug.Log("¡" + itemData.itemName + " absorbido permanentemente!");
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                canAbsorb = true;
                GameManager.Instance.ShowInteractPrompt("Presiona E para absorber " + itemData.itemName);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                canAbsorb = false;
                GameManager.Instance.HideInteractPrompt();
            }
        }
    }
}