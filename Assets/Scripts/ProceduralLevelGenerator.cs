using UnityEngine;
using System.Collections.Generic;

public class ProceduralLevelGenerator : MonoBehaviour
{
    public GameObject[] roomPrefabs; // 4 tipos de habitaciones (asignar en Inspector)
    public GameObject bossRoomPrefab;

    private List<Vector2> generatedRoomsPositions = new List<Vector2>();
    private int roomsGenerated = 0;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        // Generar habitaciones iniciales
        for (int i = 0; i < 5; i++) // Ejemplo: 5 habitaciones por nivel
        {
            Vector2 newPos = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            if (!generatedRoomsPositions.Contains(newPos))
            {
                GameObject roomPrefab = (roomsGenerated >= 2 && Random.value > 0.5f) ? bossRoomPrefab : roomPrefabs[Random.Range(0, roomPrefabs.Length)];
                Instantiate(roomPrefab, newPos, Quaternion.identity);
                generatedRoomsPositions.Add(newPos);
                roomsGenerated++;
            }
        }
    }
}