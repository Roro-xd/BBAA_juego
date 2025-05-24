using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int damage = 1;
    public float lifetime = 5f;
    public GameObject hitEffect; // Efecto visual al impactar

    // Variables para movimiento controlado externamente
    public Vector2 direccion;
    public float velocidad;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Mover el proyectil en la dirección con velocidad
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vida playerVida = other.GetComponent<Vida>();
            if (playerVida != null)
            {
                playerVida.RecibeDano(damage);
            }
        }

        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}