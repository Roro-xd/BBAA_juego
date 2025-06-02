using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject jugadorPrefab; // Asigna el prefab del jugador en el Inspector

    void Start()
    {
        if (jugadorPrefab != null)
        {
            GameObject nuevoJugador = Instantiate(jugadorPrefab, transform.position, Quaternion.identity);
            Debug.Log("Jugador instanciado en SpawnPoint.");
        }
        else
        {
            Debug.LogError("No se asignó el prefab del jugador en el SpawnManager.");
        }
    }
}
