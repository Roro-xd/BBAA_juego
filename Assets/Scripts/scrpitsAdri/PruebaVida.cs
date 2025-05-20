using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaVida : MonoBehaviour
{
    private Vida vida;

    void Start()
    {
        vida = GetComponent<Vida>();
        
        Debug.Log("PruebaVida iniciado. Vida encontrada: " + (vida != null));
  

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))  // Daño al presionar J
        {
            vida.RecibeDano(1);
        }

        if (Input.GetKeyDown(KeyCode.H))  // Cura al presionar H
        {
            vida.Curar(1);
        }
    }
}
