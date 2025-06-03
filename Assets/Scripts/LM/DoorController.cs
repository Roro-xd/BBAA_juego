/*using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject[] doors; // 0=Up, 1=Down, 2=Left, 3=Right
    public bool isLocked = false;

    public void LockDoors()
    {
        isLocked = true;
        foreach (GameObject door in doors)
        {
            door.SetActive(true); // Activa colliders/bloqueos
        }
    }

    public void UnlockDoors()
    {
        isLocked = false;
        foreach (GameObject door in doors)
        {
            door.SetActive(false); // Desactiva colliders
        }
    }
}*/