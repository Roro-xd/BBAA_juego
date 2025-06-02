using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Buscando al jugador...");
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        if (jugador != null)
        {
            jugador.transform.position = transform.position; // Mueve al jugador al SpawnPoint
            Debug.Log("Jugador movido al SpawnPoint: " + transform.position);
        }
        else
        {
            Debug.LogError("No se encontró un objeto con el tag 'Jugador'. Revisa el tag en el Inspector.");
        }
    }
}