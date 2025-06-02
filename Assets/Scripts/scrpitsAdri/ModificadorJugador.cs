using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificadorJugador : MonoBehaviour
{
    public void AplicarIncrementoVida(int cantidad)
    {
        if (Vida.Instance != null)
        {
            Vida.Instance.AumentoVidaMax(cantidad);
        }
    }

    public void AplicarIncrementoVelocidad(float cantidad)
    {
       if (Vida.Instance != null)
{
    Vida.Instance.AumentoVelocidad(cantidad);
}
    }

    public void AplicarIncrementoDano(int cantidad)
{
    if (Vida.Instance != null)
    {
        Vida.Instance.SubeAtaque(cantidad);
    }
}

}
