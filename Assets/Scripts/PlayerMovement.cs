using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove) return;

        // Input de movimiento (WASD o flechas)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Orientación del sprite (voltear horizontalmente)
        if (movement.x != 0)
        {
            GetComponent<SpriteRenderer>().flipX = movement.x < 0;
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            // Movimiento suavizado
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void ToggleMovement(bool enable)
    {
        canMove = enable;
    }
}