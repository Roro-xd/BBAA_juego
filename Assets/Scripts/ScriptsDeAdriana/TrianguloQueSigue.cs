using System.Collections;
using UnityEngine;

public class TrianguloQueSigue : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; // Cambiado el nombre para evitar conflicto
    public Transform spawner;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Color colorOriginal;
    
    [SerializeField] private GameObject player; // Mejor usar SerializeField para referencias
    private AtaqueMelee playerAttack; // Cachear componente
    
    bool siAtaco = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorOriginal = spriteRenderer.color;
        animator = GetComponent<Animator>();
        
        // Buscar cámara automáticamente si no está asignada
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
            if(mainCamera == null)
            {
                Debug.LogError("No se encontró la cámara principal. Asegúrate de tener una cámara con tag 'MainCamera'");
            }
        }

        // Buscar jugador y su componente de ataque
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
        if(player != null)
        {
            playerAttack = player.GetComponent<AtaqueMelee>();
            if(playerAttack == null)
            {
                Debug.LogError("El jugador no tiene componente AtaqueMelee");
            }
        }
    }

    void Update()
    {
        RotateTowardsMouse();
        CheckFiring();
    }

    private void RotateTowardsMouse()
    {
        float angle = GetAngleTowardsMouse();
        transform.rotation = Quaternion.Euler(0, 0, angle);
        spriteRenderer.flipY = angle >= 90 && angle <= 270;
    }

    private float GetAngleTowardsMouse()
    {
        if(mainCamera == null) return 0f; // Prevenir error si no hay cámara
        
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;

        return (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;
    }

    private void CheckFiring()
    {
        if(playerAttack == null) return;
        
        // Lógica de color optimizada
        if (!playerAttack.siPuedoAtacar && !siAtaco)
        {
            spriteRenderer.color = Color.gray;
        }
        else if (siAtaco)
        {
            spriteRenderer.color = playerAttack.siAcierta ? Color.yellow : colorOriginal;
        }
        else
        {
            spriteRenderer.color = colorOriginal;
        }

        if (Input.GetMouseButtonDown(0) && !siAtaco)
        {
            siAtaco = true;
            animator.SetBool("siAtaca", true);
            StartCoroutine(Ataque());
        }
    }

    IEnumerator Ataque()
    {
        yield return new WaitForSeconds(0.3f);
        siAtaco = false;
        animator.SetBool("siAtaca", false);
        spriteRenderer.color = colorOriginal;
    }
}