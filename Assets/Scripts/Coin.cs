using UnityEngine;

public class Coin : MonoBehaviour
{
    // Variable pública para modificar el valor de la moneda desde Unity
    public int coinValue = 1;  // Valor de la moneda (puede ser cualquier número, incluso más de 1)

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            CollectCoin();
        }
    }

    void CollectCoin()
    {
        GameManager.Instance.AddCoins(coinValue); // Suma el valor de la moneda al contador
        GameManager.Instance.HideInteractPrompt(); // Oculta el mensaje de interacción
        Destroy(gameObject); // Destruye el objeto moneda
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            GameManager.Instance.ShowInteractPrompt("Presiona E para recoger moneda (Valor: " + coinValue + ")");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            GameManager.Instance.HideInteractPrompt();
        }
    }
}
