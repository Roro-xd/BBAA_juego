using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public Button character1Button;
    public Button character2Button;
    public GameObject character1; // Arrastra el GameObject del personaje 1 desde la jerarquía
    public GameObject character2; // Arrastra el GameObject del personaje 2 desde la jerarquía
    public Transform spawnPoint; // Opcional: Si quieres respawnearlos en una posición

    void Start()
    {
        // Configuración inicial: Desactivar movimiento de ambos
        character1.GetComponent<PlayerMovement>().enabled = false;
        character2.GetComponent<PlayerMovement>().enabled = false;

        // Asignar listeners a los botones
        character1Button.onClick.AddListener(() => SelectCharacter(0));
        character2Button.onClick.AddListener(() => SelectCharacter(1));
    }

    public void SelectCharacter(int index)
    {
        // Activar el personaje seleccionado y desactivar el otro
        character1.SetActive(index == 0);
        character2.SetActive(index == 1);

        // Mover al spawnPoint (opcional)
        if (spawnPoint != null)
        {
            character1.transform.position = spawnPoint.position;
            character2.transform.position = spawnPoint.position;
        }

        // Habilitar el movimiento del personaje seleccionado
        if (index == 0)
        {
            character1.GetComponent<PlayerMovement>().enabled = true;
            character1.tag = "Player"; // Asegurar la etiqueta para interacciones
        }
        else
        {
            character2.GetComponent<PlayerMovement>().enabled = true;
            character2.tag = "Player";
        }

        // Desactivar la UI de selección
        gameObject.SetActive(false); 
    }
}