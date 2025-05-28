using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float detectionRadius = 7f;
    public float attackCooldown = 1f;
    public int attackDamage = 10;

    [Header("Combat Settings")]
    public int maxHealth = 30;  // Salud máxima
    private int currentHealth;   // Salud actual

    [Header("Loot System")]
    public GameObject coin1Prefab;
    public GameObject coin5Prefab;
    [Range(0f, 1f)] public float chanceFor5 = 0.1f;

    [Header("Animation Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private string moveParam = "IsMoving";
    [SerializeField] private string attackParam = "Attack";

    [Header("Layer Settings")]
    [SerializeField] private LayerMask playerLayer;

    private Transform playerTarget;
    private Rigidbody2D rb;
    private bool isChasing;
    private float lastAttackTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        currentHealth = maxHealth;  // Inicializa la salud
        FindPlayer();

        // Auto-referenciar Animator si no está asignado
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerTarget == null) FindPlayer();
        UpdateDetection();
        HandleAnimations();

    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void FindPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) playerTarget = playerObj.transform;
    }

    void UpdateDetection()
    {
        if (playerTarget == null) return;

        Collider2D hit = Physics2D.OverlapCircle(
            transform.position,
            detectionRadius,
            playerLayer
        );

        isChasing = (hit != null);
    }

    void HandleMovement()
    {
        if (isChasing && playerTarget != null)
        {
            /*if (this.gameObject.name == "Asesina")
            { 
                AudioManager.Instance.PlayOtros("caminadoRapido");
            }
            if (this.gameObject.name == "Tanque")
            { 
                AudioManager.Instance.PlayOtros("caminadoLento");
            }*/
    

            Vector2 direction = (playerTarget.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
            FlipSprite(direction.x);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void HandleAnimations()
    {
        if (animator != null)
        {
            animator.SetBool(moveParam, isChasing);
        }
    }

    void FlipSprite(float xDirection)
    {
        if (xDirection != 0)
        {
            transform.localScale = new Vector3(
                Mathf.Sign(xDirection) * Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
           Time.time > lastAttackTime + attackCooldown)
        {
            AttackPlayer(collision.gameObject);
            lastAttackTime = Time.time;
        }
    }

    void AttackPlayer(GameObject player)
    {
        CharacterStats playerStats = player.GetComponent<CharacterStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(attackDamage);
            if (animator != null)
            {
                animator.SetTrigger(attackParam);
            }
        }
    }

    // Método para recibir daño del jugador
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // Restar la salud actual
        Debug.Log("Vida del enemigo: " + currentHealth);

        if (currentHealth <= 0) Die();  // Si la salud llega a 0, el enemigo muere
    }

    // Método para la muerte del enemigo
    void Die()
    {
        DropLoot();
        Destroy(gameObject);  // Destruir el objeto del enemigo
        Debug.Log("El enemigo ha muerto");
    }

    public void DropLoot()
    {
        if (coin1Prefab == null || coin5Prefab == null) return;

        GameObject coinPrefab = Random.value < chanceFor5 ? coin5Prefab : coin1Prefab;
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

