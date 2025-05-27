using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoModificador
{
    Vida,
    Velocidad,
    Dano
}

public class ObjetoRecolectable : MonoBehaviour
{
    public TipoModificador tipoModificador;

    public int cantidadVida = 5;
    public float cantidadVelocidad = 0.5f;
    public int cantidadDano = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ModificadorJugador modificador = other.GetComponent<ModificadorJugador>();

        if (modificador != null)
        {
            switch (tipoModificador)
            {
                case TipoModificador.Vida:
                    modificador.AplicarIncrementoVida(cantidadVida);
                    break;

                case TipoModificador.Velocidad:
                    modificador.AplicarIncrementoVelocidad(cantidadVelocidad);
                    break;

                case TipoModificador.Dano:
                    modificador.AplicarIncrementoDano(cantidadDano);
                    break;
            }

            Destroy(gameObject);
        }
    }
}
