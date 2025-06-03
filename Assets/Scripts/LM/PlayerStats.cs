/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int vidaMax = 4;
    public int vidaAct;

    public delegate void CambioVida(int actual, int max);
    public event CambioVida SiCambiaVida;

    public static PlayerStats Instance;
    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this; DontDestroyOnLoad(gameObject);
        }


   }

    void Start()
    {
        vidaAct = vidaMax;

    }
    public void DPS()
    {
        vidaAct -= 1;
        vidaAct = Mathf.Clamp(vidaAct, 0, vidaMax);

        if (SiCambiaVida != null)
        {
            SiCambiaVida(vidaAct, vidaMax);
        }

        if (vidaAct <= 0) 
        {


        }

    }
}*/