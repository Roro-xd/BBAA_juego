using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaMaxima = 3;
    public int vidaActual;

    private EnemyController enemyController;  // Referencia al EnemyController

    private void Start()
    {
        vidaActual = vidaMaxima;
        // Obtiene el EnemyController si está presente en el mismo GameObject
        enemyController = GetComponent<EnemyController>();
    }

    public void RecibirDano(int cantidad)
    {
        vidaActual -= cantidad;
        AudioManager.Instance.PlaySFX("DanoEnemigo");

        this.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(colorOriginal());

        Debug.Log(gameObject.name + " recibió daño. Vida restante: " + vidaActual);

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log(gameObject.name + " ha muerto.");
        AudioManager.Instance.PlaySFX("MuerteEnemigo");

        // Llama al DropLoot() del EnemyController antes de destruir al enemigo
        if (enemyController != null)
        {
            enemyController.DropLoot();
        }

        // Destruir el objeto enemigo después de que haya soltado el loot
        Destroy(gameObject);
    }


    IEnumerator colorOriginal()
    {
        yield return new WaitForSeconds(0.25f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
     }
}