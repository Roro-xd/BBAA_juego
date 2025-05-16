using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int vidaMax = 4;
    public int vidaAct;

public delegate void CambioVida(int actual, int max);
    public event CambioVida CambioVida;

    void Start()
    {
        vidaAct = vidaMax;
        
    }
    public void Daño()
    {
        vidaAct -= cantidad;
        vidaAct = Mathf.Clamp(vidaAct, 0, vidaMax);

        CambioVida? Invoke(vidaAct, vidaMax);

        if (currentHealth <= 0) ;
        {
            Muerto();
            }
        
    }
}