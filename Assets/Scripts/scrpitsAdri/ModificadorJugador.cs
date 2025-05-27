using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificadorJugador : MonoBehaviour
{
    public void AplicarIncrementoVida(int cantidad)
    {
        Vida vida = GetComponent<Vida>();
        if (vida != null)
        {
            vida.AumentoVidaMax(cantidad);
        }
    }

    public void AplicarIncrementoVelocidad(float cantidad)
    {
        Caminar caminar = GetComponent<Caminar>();
        if (caminar != null)
        {
            caminar.velomov += cantidad;
        }
    }

    public void AplicarIncrementoDano(int cantidad)
    {
        AtaqueMelee ataque = GetComponent<AtaqueMelee>();
        if (ataque != null)
        {
            ataque.SubeAtaque(cantidad);
        }
    }
}