using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public float vidaMax = 4f;
    public float vidaActual = 4f;
    public float velomov= 2f;
    public int dano = 1;

    public int nivelChurro = 0;
    public int nivelNapo = 0;
    public int nivelYori = 0;

   

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}