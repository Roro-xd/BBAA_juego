using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaExpendedora : MonoBehaviour
{
    public List<GameObject> objetosDisponibles;
    public Transform puntoDeSpawn;
    public float duracionVibracion = 0.5f;
    public float intensidadVibracion = 0.1f;
    public int costo = 3;

    private bool enUso = false;
    private bool agotada = false;
    private Vector3 posicionOriginal;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        posicionOriginal = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        /*if (Vida.Instance != null)
        {
            Vida.Instance.monedas = 0;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enUso || agotada) return;

        if (other.CompareTag("Player"))
        {
            Vida jm = other.GetComponent<Vida>();
            if (jm != null && jm.monedas >= costo)
            {
                jm.monedas -= costo;
                StartCoroutine(ActivarMaquina());
            }
            else
            {
                Debug.Log("No tienes suficientes monedas.");
            }
        }
    }

    private IEnumerator ActivarMaquina()
    {
        enUso = true;
        AudioManager.Instance.PlaySFX("MaquinaExp");

        float tiempo = 0f;
        while (tiempo < duracionVibracion)
        {
            Vector3 offset = new Vector3(
                Random.Range(-intensidadVibracion, intensidadVibracion),
                Random.Range(-intensidadVibracion, intensidadVibracion),
                0f
            );
            transform.position = posicionOriginal + offset;
            tiempo += Time.deltaTime;
            yield return null;
        }

        transform.position = posicionOriginal;

        if (objetosDisponibles.Count > 0)
        {
            int indice = Random.Range(0, objetosDisponibles.Count);
            GameObject objetoSeleccionado = objetosDisponibles[indice];

            Instantiate(objetoSeleccionado, puntoDeSpawn.position, Quaternion.identity);
            objetosDisponibles.RemoveAt(indice);
        }

        if (objetosDisponibles.Count == 0)
        {
            agotada = true;
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f); // tono gris
            }
            Debug.Log("La máquina expendedora se ha agotado.");
        }

        enUso = false;
    }
}