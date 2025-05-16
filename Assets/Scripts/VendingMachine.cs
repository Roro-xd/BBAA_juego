using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public int itemPrice = 10;

    private bool isPlayerNear;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && GameManager.Instance.currentCoins >= itemPrice)
        {
            GameManager.Instance.currentCoins -= itemPrice;
            GameManager.Instance.playerStrength += 1; // Mejora placeholder
            Debug.Log("¡Item comprado!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}