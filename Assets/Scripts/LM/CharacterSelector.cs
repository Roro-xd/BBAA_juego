/*using UnityEngine;
using UnityEngine.UI;
using Cinemachine; // Añade esta línea para usar Cinemachine

public class CharacterSelector : MonoBehaviour
{
    [Header("Referencias UI")]
    public Button character1Button;
    public Button character2Button;

    [Header("Personajes")]
    public GameObject character1; 
    public GameObject character2; 
    public Transform spawnPoint;

    [Header("Cinemachine")]
    public CinemachineVirtualCamera virtualCamera; // Arrastra la cámara de Cinemachine aquí

    void Start()
    {
        // Desactivar movimiento inicialmente
        ToggleCharacterComponents(false);

        // Asignar listeners a los botones
        character1Button.onClick.AddListener(() => SelectCharacter(0));
        character2Button.onClick.AddListener(() => SelectCharacter(1));
    }

    void ToggleCharacterComponents(bool state)
    {
        character1.GetComponent<PlayerMovement>().enabled = state;
        character2.GetComponent<PlayerMovement>().enabled = state;
    }

    public void SelectCharacter(int index)
    {
        // Activar personaje seleccionado y desactivar el otro
        character1.SetActive(index == 0);
        character2.SetActive(index == 1);

        // Mover al punto de spawn (si está asignado)
        if (spawnPoint != null)
        {
            character1.transform.position = spawnPoint.position;
            character2.transform.position = spawnPoint.position;
        }

        // Configurar Cinemachine para seguir al personaje seleccionado
        SetCameraTarget(index == 0 ? character1.transform : character2.transform);

        // Activar componentes del personaje seleccionado
        if (index == 0)
        {
            character1.GetComponent<PlayerMovement>().enabled = true;
            character1.tag = "Player";
        }
        else
        {
            character2.GetComponent<PlayerMovement>().enabled = true;
            character2.tag = "Player";
        }

        // Desactivar la UI de selección
        gameObject.SetActive(false); 
    }

    // Actualiza el objetivo de la cámara de Cinemachine
    void SetCameraTarget(Transform target)
    {
        virtualCamera.Follow = target;
        virtualCamera.LookAt = target;
    }
}*/