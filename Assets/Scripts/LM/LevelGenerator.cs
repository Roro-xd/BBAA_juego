/*using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] normalRooms;
    public GameObject bossRoom;
    public GameObject startRoom;
    public int minRoomsBeforeBoss = 3;

    private List<GameObject> spawnedRooms = new List<GameObject>();

    void Start()
    {
        GenerateLayout();
    }

    void GenerateLayout()
    {
        // 1. Generar habitación inicial
        GameObject start = Instantiate(startRoom, Vector2.zero, Quaternion.identity);
        spawnedRooms.Add(start);

        // 2. Generar habitaciones normales
        int totalRooms = Random.Range(4, 7);
        Vector2 lastPosition = Vector2.zero;

        for (int i = 0; i < totalRooms; i++)
        {
            Vector2 newPos = lastPosition + new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            GameObject roomPrefab = (i >= minRoomsBeforeBoss) ? bossRoom : normalRooms[Random.Range(0, normalRooms.Length)];
            
            GameObject room = Instantiate(roomPrefab, newPos, Quaternion.identity);
            spawnedRooms.Add(room);
            lastPosition = newPos;
        }

        // 3. Conectar habitaciones (implementar lógica de puertas)
    }
}*/